//#region global variable
const answerNumber = 0;

var vocabularyTypeIDSelected;
var quizTypeIDSelected;
var originalVocabularyWords;
var quizVocabularyWords;
var currentItemQuizVocabularyWord;
var vocabularyWordHistories = [];

var numberOfCorrectAnswers = 0;
var numberOfIncorrectAnswers = 0;


const container = $('.fireworks');
const fireworks = new Fireworks.default(container[0]);

//#endregion

function setOptionQuizTypes(quizTypes, elementID) {
    const selectElement = $(`#${elementID}`);

    $.each(quizTypes, function (index, quizType) {
        selectElement.append($('<option>', {
            value: quizType.QuizTypeID,
            text: quizType.Name
        }));
    });
}

function setRangeVocabularyIndex(vocabularyWords) {
    $("#vocabulary-start-index").val(vocabularyWords.length != 0 ? 1 : 0);
    $("#vocabulary-end-index").val(vocabularyWords.length);
}

function getAllVocabularyWord(vocabularyTypeID) {
    let result;
    $.ajax({
        method: "GET",
        async: false,
        url: `/vocabulary-words/get-all-vocabulary-words/${vocabularyTypeID}`,
    })
        .done(function (response) {
            result = response;
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });

    return result;
}

function randomOptionQuizType(quizTypes) {
    if (quizTypes.length === 0) {
        return null;
    }

    const randomIndex = Math.floor(Math.random() * quizTypes.length);
    return quizTypes[randomIndex];
}

//#region init quizVocabularyWords
function getVocabularyWordsByVocabularyIndex() {
    let vocabularyStartIndex = $("#vocabulary-start-index").val();
    let vocabularyEndIndex = $("#vocabulary-end-index").val();

    let vocabularyWords = [];
    originalVocabularyWords.forEach(function (item, index) {
        if (index >= vocabularyStartIndex - 1 && index <= vocabularyEndIndex - 1) {
            vocabularyWords.push(item);
        }
    })

    ShowToastSuccess("Initialization of vocabulary words successfully.");

    return vocabularyWords;
}
//#endregion

function randomVocabularyWordInsideQuizVocabularyWord(isDeleteItem = false) {
    if (quizVocabularyWords.length === 0) {
        return null;
    }

    const randomIndex = Math.floor(Math.random() * quizVocabularyWords.length);
    const randomItem = quizVocabularyWords[randomIndex];

    if (isDeleteItem) {
        quizVocabularyWords.splice(randomIndex, 1);
    }

    return randomItem;
}

//#region setVocabularyWordHistories And Reload Table
function setVocabularyWordHistoriesAndReloadTable() {
    vocabularyWordHistories.push(currentItemQuizVocabularyWord);
    vocabularyWordHistoriesDatatable.clear();
    vocabularyWordHistoriesDatatable.rows.add(vocabularyWordHistories);
    vocabularyWordHistoriesDatatable.draw();
}
//#endregion

//#region quiz type: fill in the blank
function renderQuizTypeFillInTheBlank() {
    $("#quiz-type-choose").hide();
    $("#quiz-type-fill").show();

    if (currentItemQuizVocabularyWord == null || currentItemQuizVocabularyWord == undefined)
        return;

    $("#vocabulary-word-question").html(`${currentItemQuizVocabularyWord.definition}<br><span class="vocabulary-info">${currentItemQuizVocabularyWord.pronunciation}</span>`);
    if (currentItemQuizVocabularyWord.audioClips.length > 0) {
        $("#audio-vocabulary-word-question").data("audioclipid", currentItemQuizVocabularyWord.audioClips[0].audioClipID);
    }
}

function checkAnswerVocabularyWord() {
    let answerVocabularyWord = $("#answer-vocabulary-word").val();
    if (answerVocabularyWord.trim().toLowerCase() === currentItemQuizVocabularyWord.word.trim().toLowerCase()) {
        ShowToastSuccess("You answered correctly!");
        setVocabularyWordHistoriesAndReloadTable();
        numberOfCorrectAnswers++;
        setNumberOfCorrectAnswers();
        $("#answer-vocabulary-word").val("");
        playAudio();
        renderQuizTypes();
    }
    else {
        numberOfIncorrectAnswers++;
        setNumberOfIncorrectAnswers();
        ShowToastError("You answered wrong. Please try again.");
    }
}

$("#check-answer-vocabulary-word").click(function () {
    checkAnswerVocabularyWord();
})


$("#show-answer-vocabulary-word").click(function () {
    ShowToastInfo(currentItemQuizVocabularyWord.word);
})

$("#answer-vocabulary-word").keypress(function (e) {
    if (e.which === 13) {
        checkAnswerVocabularyWord();
    }
});

//#endregion

//#region quiz type: choose the correct answer
function initVocabularyWordChooseAnswer() {
    let vocabularyWordsChooseAnswer = [];
    for (let i = 0; i < 3; i++) {
        vocabularyWordsChooseAnswer.push(randomVocabularyWordInsideQuizVocabularyWord(false))
    }
    vocabularyWordsChooseAnswer.push(currentItemQuizVocabularyWord);
    shuffleArray(vocabularyWordsChooseAnswer);
    return vocabularyWordsChooseAnswer;
}

function renderQuizTypeChooseAnswer(vocabularyWordsChooseAnswer) {
    $("#quiz-type-fill").hide();
    $("#quiz-type-choose").show();

    if (currentItemQuizVocabularyWord == null || currentItemQuizVocabularyWord == undefined)
        return;

    $("#vocabulary-word-question").text(currentItemQuizVocabularyWord.definition);
    if (currentItemQuizVocabularyWord.audioClips.length > 0) {
        $("#audio-vocabulary-word-question").data("audioclipid", currentItemQuizVocabularyWord.audioClips[0].audioClipID);
    }

    $("#quiz-type-choose").empty();

    vocabularyWordsChooseAnswer.forEach(function (item, index) {
        if (item != null) {
            let choiceElement = $(`<div onclick="checkVocabularyWordChooseAnswer(${item.vocabularyWordID})" class="col-md-6"><div class="form-group card-choose"><label for="word"> ${index + 1}. ${item.word} </label></div></div>`);

            $("#quiz-type-choose").append(choiceElement);
        }
    });
}

function checkVocabularyWordChooseAnswer(vocabularyWordID) {
    if (vocabularyWordID === currentItemQuizVocabularyWord.vocabularyWordID) {
        ShowToastSuccess("You answered correctly!");
        numberOfCorrectAnswers++;
        setNumberOfCorrectAnswers();
        setVocabularyWordHistoriesAndReloadTable();
        playAudio();
        renderQuizTypes();
    }
    else {
        numberOfIncorrectAnswers++;
        setNumberOfIncorrectAnswers();
        ShowToastError("You answered wrong. Please try again.");
    }
}
//#endregion

function renderQuizTypes() {
    quizTypeIDSelected = $('#quiz-types').find(":selected").val();
    currentItemQuizVocabularyWord = randomVocabularyWordInsideQuizVocabularyWord(true);

    if (currentItemQuizVocabularyWord == null || currentItemQuizVocabularyWord == undefined) {
        $("#block-quiz").hide();
        ShowToastSuccess("Quiz completed successfully.");
    }

    if (quizTypeIDSelected === "1") {
        let quizTypeID = Math.floor(Math.random() * 2) + 1;
        if (quizTypeID === 1) {
            let vocabularyWordsChooseAnswer = initVocabularyWordChooseAnswer();
            renderQuizTypeChooseAnswer(vocabularyWordsChooseAnswer);
        }
        else {
            renderQuizTypeFillInTheBlank();
        }
    }

    if (quizTypeIDSelected === "2") {
        renderQuizTypeFillInTheBlank();
    }

    if (quizTypeIDSelected === "3") {
        let vocabularyWordsChooseAnswer = initVocabularyWordChooseAnswer();
        renderQuizTypeChooseAnswer(vocabularyWordsChooseAnswer);
    }
}

$(document).ready(function () {
    const quizTypes = [{ "QuizTypeID": 1, "Name": "All" }, { "QuizTypeID": 2, "Name": "Fill in the blank" }, { "QuizTypeID": 3, "Name": "Choose the correct answer" }];
    setOptionQuizTypes(quizTypes, "quiz-types")

    vocabularyTypeIDSelected = $('#vocabulary-types').find(":selected").val();
    originalVocabularyWords = getAllVocabularyWord(vocabularyTypeIDSelected);

    setRangeVocabularyIndex(originalVocabularyWords);
});

$("#start-quiz").on("keydown", function (e) {
    if (e.key === "Enter" || e.key === " ") {
        e.preventDefault();
    }
});

$("#start-quiz").on("click", function () {
    numberOfCorrectAnswers = 0;
    setNumberOfCorrectAnswers();

    numberOfIncorrectAnswers = 0;
    setNumberOfIncorrectAnswers();


    if (vocabularyWordHistories.length > 0) {
        vocabularyWordHistories = [];
        vocabularyWordHistoriesDatatable.clear();
        vocabularyWordHistoriesDatatable.rows.add(vocabularyWordHistories);
        vocabularyWordHistoriesDatatable.draw();
    }

    openFireworks();
    quizVocabularyWords = getVocabularyWordsByVocabularyIndex();
    $("#block-quiz").show();
    renderQuizTypes();
});

$("#vocabulary-types").change(function () {
    vocabularyTypeIDSelected = $('#vocabulary-types').find(":selected").val();
    originalVocabularyWords = getAllVocabularyWord(vocabularyTypeIDSelected);
    setRangeVocabularyIndex(originalVocabularyWords);
});

function shuffleArray(array) {
    for (let i = array.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [array[i], array[j]] = [array[j], array[i]];
    }
}

function playAudio() {
    const audioClipID = $("#audio-vocabulary-word-question").data("audioclipid");

    fetch(`${URLServer}/api/mp3/open/${audioClipID}`)
        .then(response => {
            if (response.ok) {
                return response.blob();
            }
            ShowToastError("Không thể tải âm thanh.");
        })
        .then(blob => {
            const audioURL = URL.createObjectURL(blob);
            audioPlayer.src = audioURL;
            audioPlayer.play();
        })
        .catch(error => {
            console.error(error);
        });
}


//#region render table history learn vocabulary word
var vocabularyWordHistoriesDatatable = $("#vocabularyWordHistoriesDatatable").DataTable({
    "lengthChange": false,
    "processing": true,
    "responsive": true,
    "paging": false,
    "searching": false,
    "info": false,
    'language': {
        'loadingRecords': '&nbsp;',
        'processing': `<div class="spinner-border" style="width: 3rem; height: 3rem" role="status">
                        <span class="visually-hidden">Loading...</span>
                      </div>`
    },
    "data": vocabularyWordHistories,
    "columnDefs": [
        {
            targets: [1],
            className: 'wrap-text',
        },
        {
            className: "text-start",
            targets: [1]
        }],
    "columns": [
        {
            "Width": "5%",
            "render": function (data, type, row, meta) {
                return meta.row + 1;
            },
        },
        {
            "name": "Vocabulary Word",
            "render": function (row, type, data) {
                let html = `<span>${data.word}</span><span style="font-style: italic; color: green;">${data.definition}</span>`;
                return `<div class="d-flex gap-2" style="flex-direction: column;">
                            ${html}
                        </div>`;
            }
        },
        {
            "name": "AudioClips", "Width": "5%",
            "render": function (row, type, data) {
                let html = "";

                if (data.audioClips.length > 0) {
                    data.audioClips.forEach((item) => {
                        html += `<a href="javascript:void(0)" onclick="playAudioWithAudioClipID(${item.audioClipID})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #004d5c; padding: 0px;" ><i class="fa-solid fa-volume" style="color: #646462;"></i></a>`
                    })
                }

                return `<div class="d-flex gap-2 justify-content-center">
                            ${html}
                        </div>`;
            }
        },
    ]
});
//#endregion

function playAudioWithAudioClipID(audioClipID) {
    fetch(`${URLServer}/api/mp3/open/${audioClipID}`)
        .then(response => {
            if (response.ok) {
                return response.blob();
            }
            ShowToastError("Không thể tải âm thanh.");
        })
        .then(blob => {
            const audioURL = URL.createObjectURL(blob);
            audioPlayer.src = audioURL;
            audioPlayer.play();
        })
        .catch(error => {
            console.error(error);
        });
}

function setNumberOfCorrectAnswers() {
    $("#number-of-correct-answers").text(numberOfCorrectAnswers);
}

function setNumberOfIncorrectAnswers() {
    $("#number-of-incorrect-answers").text(numberOfIncorrectAnswers);
}

function openFireworks() {
    container.css({
            'z-index': 9999,
            'background-color': 'rgba(0, 0, 0, 0.3)'
        });

    fireworks.start();

    setTimeout(() => {
        fireworks.stop();
        container.css({
            'z-index': -1,
            'background-color': 'rgba(0, 0, 0, 0.0)'
        });
    }, 5000);
}