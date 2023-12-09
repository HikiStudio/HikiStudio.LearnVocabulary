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

const quizTypes = [
    { "QuizTypeID": 1, "Name": "All" },
    { "QuizTypeID": 2, "Name": "Fill in the blank (Word)" },
    { "QuizTypeID": 3, "Name": "Choose the correct answer" },
    { "QuizTypeID": 4, "Name": "Fill in the blank (Definition)" }
];
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
    let courseID = $("#hdCourseID").val();

    if (courseID === null || courseID === undefined || courseID === "") {
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
    else {
        let result;
        $.ajax({
            method: "GET",
            async: false,
            url: `/vocabulary-words/get-vocabulary-word-by-course-id/${courseID}`,
        })
            .done(function (response) {
                result = response;
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
        return result;
    }
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
    vocabularyWordHistories.unshift(currentItemQuizVocabularyWord);
    vocabularyWordHistoriesDatatable.clear();
    vocabularyWordHistoriesDatatable.rows.add(vocabularyWordHistories);
    vocabularyWordHistoriesDatatable.draw();
}
//#endregion

//#region quiz type: fill in the blank
function renderQuizTypeFillInTheBlank(option) {
    $("#quiz-type-choose").hide();
    $("#quiz-type-fill").show();

    if (currentItemQuizVocabularyWord == null || currentItemQuizVocabularyWord == undefined)
        return;

    //fill word
    if (option === 2) {
        $("#vocabulary-word-question").html(`${currentItemQuizVocabularyWord.definition}`);
    }
    //fill definition
    if (option === 4) {
        $("#vocabulary-word-question").html(`${currentItemQuizVocabularyWord.word}<br><span class="vocabulary-info">${currentItemQuizVocabularyWord.pronunciation}</span>`);
    }

    if (currentItemQuizVocabularyWord.audioClips.length > 0) {
        $("#audio-vocabulary-word-question").data("audioclipid", currentItemQuizVocabularyWord.audioClips[0].audioClipID);
    }
}


function checkAnswerStandardized(data, answer) {
    const rightAnswers = data.split(',').map(item => item.trim().toLowerCase());

    const answerStandardized = answer.trim().toLowerCase();
    const isAnswerCorrect = rightAnswers.some(rightAnswer => answerStandardized.includes(rightAnswer));

    return isAnswerCorrect;
}


function checkAnswerVocabularyWord() {
    let answerVocabularyWord = $("#answer-vocabulary-word").val();
    if (answerVocabularyWord !== "" && answerVocabularyWord !== undefined) {
        if (checkAnswerStandardized(answerVocabularyWord, currentItemQuizVocabularyWord.word)) {
            ShowToastSuccess("You answered correctly!");
            setVocabularyWordHistoriesAndReloadTable();
            numberOfCorrectAnswers++;
            setNumberOfCorrectAnswers();
            $("#answer-vocabulary-word").val("");
            playAudio();
            renderQuizTypes();
        }
        else if (checkAnswerStandardized(answerVocabularyWord, currentItemQuizVocabularyWord.definition)) {
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
}

$("#check-answer-vocabulary-word").click(function () {
    let word = $("#answer-vocabulary-word").val();
    if (word !== "" && word !== undefined) {
        checkAnswerVocabularyWord();
    }
})


$("#show-answer-vocabulary-word").click(function () {
    ShowToastInfo(`${currentItemQuizVocabularyWord.word} /${currentItemQuizVocabularyWord.pronunciation}/ : ${currentItemQuizVocabularyWord.definition}`);
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
        let quizTypeID = Math.floor(Math.random() * 3) + 2;
        if (quizTypeID === 3) {
            let vocabularyWordsChooseAnswer = initVocabularyWordChooseAnswer();
            renderQuizTypeChooseAnswer(vocabularyWordsChooseAnswer);
        }
        else {
            renderQuizTypeFillInTheBlank(quizTypeID);
        }
    }

    if (quizTypeIDSelected === "2") {
        renderQuizTypeFillInTheBlank(2);
    }

    if (quizTypeIDSelected === "3") {
        let vocabularyWordsChooseAnswer = initVocabularyWordChooseAnswer();
        renderQuizTypeChooseAnswer(vocabularyWordsChooseAnswer);
    }

    if (quizTypeIDSelected === "4") {
        renderQuizTypeFillInTheBlank(4);
    }

    let numberOfCorrectAnswers = parseInt($("#number-of-correct-answers").text());
    let numberOfIncorrectAnswers = parseInt($("#number-of-incorrect-answers").text());
    if (quizVocabularyWords.length === 0 && (currentItemQuizVocabularyWord === null || currentItemQuizVocabularyWord === undefined)) {
        if (numberOfCorrectAnswers > 0 || numberOfIncorrectAnswers > 0) {
            stopTimer();
            createCourseLearningLog(numberOfCorrectAnswers, numberOfIncorrectAnswers)
        }

        if (numberOfCorrectAnswers > 0 && numberOfIncorrectAnswers === 0) {
            openFireworks();
        }
    }
}

function getCourseInformation() {
    let courseID = $("#hdCourseID").val();

    if (courseID > 0) {
        $.ajax({
            method: "GET",
            url: `/vocabulary-courses/get-course-by-course-id/${courseID}`,
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    $("#course-name").text(response.resultObj.courseName);
                }
                else {
                    ShowToastError(response.message);
                }
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
}

function setSelectedQuizTypes() {
    let quizTypesSelect = $('#quiz-types');
    let quizTypeIDSelected = localStorage.getItem('selectedQuizTypeID');
    if (quizTypeIDSelected) {
        quizTypesSelect.val(quizTypeIDSelected);
    }
}
$(document).ready(function () {
    getCourseInformation();

    //#region quiz types
    setOptionQuizTypes(quizTypes, "quiz-types")

    setSelectedQuizTypes();

    $('#quiz-types').on('change', function () {
        let selectedOptionId = $(this).val();
        localStorage.setItem('selectedQuizTypeID', selectedOptionId);
    });
    //#endregion

    vocabularyTypeIDSelected = $('#vocabulary-types').find(":selected").val();
    originalVocabularyWords = getAllVocabularyWord(vocabularyTypeIDSelected);

    setRangeVocabularyIndex(originalVocabularyWords);

    //#region add event listener
    document.addEventListener('keydown', function (event) {
        // Check if the pressed key is 'Enter' (key code 13)
        if (event.keyCode === 13) {
            playAudio();
        }
    });
    //#endregion
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

    quizVocabularyWords = getVocabularyWordsByVocabularyIndex();
    $("#block-quiz").show();
    renderQuizTypes();

    if (!running) {
        startTimer();
    } else {
        stopTimer();
        resetTimer();
        startTimer();
    }
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
    const audioPlayer = new Audio(); // Create a new audio element

    fetch(`${URLServer}/api/mp3/open/${audioClipID}`)
        .then(response => {
            if (response.ok) {
                return response.blob();
            }
            ShowToastError("Không thể tải âm thanh.");
        })
        .then(blob => {
            const audioURL = URL.createObjectURL(blob);

            // Reset the audio player
            audioPlayer.pause();
            audioPlayer.src = '';
            audioPlayer.load();

            // Set the new audio source and play
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
    "order": [[2, 'desc']],
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
                let html = `<p style="margin: 0px;">${data.word}<span style="padding-left: 20px; font-style: italic; color: green;">/${data.pronunciation}/</span></p>
                            <span style="font-style: normal; color: blue;">${data.definition}</span>`;
                return `<div class="d-flex gap-1" style="flex-direction: column;">
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
                            <a href="javascript:void(0)" onclick="modalAssignVocabularyRelationshipType(${data.vocabularyWordID})" class="btn btn-info link-edit" style="background: transparent; border: none; color: #ff8201; padding: 0px;" ><i class="ti ti-brand-airtable"></i></a>
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

function createCourseLearningLog(numberOfCorrectAnswers, numberOfIncorrectAnswers) {
    let courseID = $("#hdCourseID").val();

    if (courseID > 0) {
        let createCourseLearningLogRequest = {
            courseID: courseID,
            log: `Incorrect: ${numberOfIncorrectAnswers} | Correct: ${numberOfCorrectAnswers}`,
            score: (numberOfCorrectAnswers / (numberOfCorrectAnswers + numberOfIncorrectAnswers) * 100),
            quizTypeID: parseInt(quizTypeIDSelected = $('#quiz-types').find(":selected").val()),
            duration: $("#timer").text(),
            learningDate: new Date().toISOString()
        }

        $.ajax({
            method: "POST",
            url: `vocabulary-quizzes/create-course-learning-log`,
            data: JSON.stringify(createCourseLearningLogRequest),
            headers: {
                "Content-Type": "application/json;",
            },
            processData: false,
            contentType: false,
            datatype: 'json',
            beforeSend: function () {
                showLoadingOverlay();
            },
            complete: function () {
                hideLoadingOverlay();
            }
        })
            .done(function (response) {
                if (response.isSuccessed === true) {
                    courseLearningLogs.ajax.reload();
                    return;
                }
                else {
                    ShowToastError(response.message);
                }

            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                ShowToastError(jqXHR.responseJSON.message);
            });
    }
}

function modalDelete() {
    let modalDelete = new bootstrap.Modal(document.getElementById('modal-logs'), {
        keyboard: false
    })
    modalDelete.show();
}

var courseIDLocal = parseInt($("#hdCourseID").val());
if (courseIDLocal > 0) {
    var courseLearningLogs = $("#courseLearningLogs").DataTable({
        "lengthChange": false,
        "processing": true,
        "serverSide": true,
        "filter": false,
        "responsive": true,
        'language': {
            'loadingRecords': '&nbsp;',
            'processing': `<div class="spinner-border" style="width: 3rem; height: 3rem" role="status">
                        <span class="visually-hidden">Loading...</span>
                      </div>`
        },
        "pagingType": 'full_numbers',
        "ajax": {
            "url": `/vocabulary-quizzes/get-paging-course-learning-logs/${courseIDLocal}`,
            "type": "POST",
            "datatype": "json"
        },
        "order": [[0, 'desc']],
        "columns": [
            {
                "data": "learningDate", "name": "LearningDate", "Width": "15%",
                "render": function (row, type, data) {
                    return formatDateTimeToDDMMYYYYHHMM(data.learningDate);
                }
            },
            {

                "data": "quizTypeID", "name": "QuizTypeID", "Width": "30%",
                "render": function (row, type, data) {
                    if (data.quizTypeID !== null && data.quizTypeID !== undefined) {
                        return quizTypes[parseInt(data.quizTypeID) - 1].Name;
                    }
                    return "";
                }
            },
            { "data": "duration", "name": "Duration", "Width": "20%" },
            { "data": "log", "name": "Log", "Width": "25%" },
            {
                "data": "score", "name": "Score", "Width": "15%",
                "render": function (row, type, data) {
                    return data.score.toFixed(2) + "%";
                }
            },
        ]
    });
}

let timerInterval;
let startTime;
let running = false;

function startTimer() {
    startTime = Date.now();
    timerInterval = setInterval(updateTimer, 1000);
    running = true;
}

function stopTimer() {
    clearInterval(timerInterval);
    running = false;
}

function resetTimer() {
    $('#timer').text('00:00:00');
    startTime = 0;
}

function updateTimer() {
    const elapsedTime = Date.now() - startTime;
    const formattedTime = formatTime(elapsedTime);
    $('#timer').text(formattedTime);
}

function formatTime(milliseconds) {
    const hours = Math.floor(milliseconds / 3600000);
    const minutes = Math.floor((milliseconds % 3600000) / 60000);
    const seconds = Math.floor((milliseconds % 60000) / 1000);
    return (
        (hours < 10 ? '0' : '') + hours + ':' +
        (minutes < 10 ? '0' : '') + minutes + ':' +
        (seconds < 10 ? '0' : '') + seconds
    );
}

//#region assign vocabulary word
var vocabularyWordIDAssign;
function modalAssignVocabularyRelationshipType(vocabularyWordID, word) {
    vocabularyWordIDAssign = vocabularyWordID;

    var myModal = new bootstrap.Modal(document.getElementById('modal-assign'), {
        keyboard: false
    })

    $.ajax({
        method: "GET",
        url: `/vocabulary-words/get-vocabulary-relationship-by-vocabulary-word-id/${vocabularyWordID}`,
    })
        .done(function (response) {
            if (response.isSuccessed === true) {
                let synonymVocabularyWords = [];
                let antonymVocabularyWords = [];

                response.resultObj.forEach((item) => {
                    if (item.vocabularyRelationshipType == 1) {
                        synonymVocabularyWords.push(item);
                    }

                    if (item.vocabularyRelationshipType == 2) {
                        antonymVocabularyWords.push(item);
                    }
                });

                // Call the function to populate synonym words
                populateVocabularyWords(synonymVocabularyWords, 'synonym-vocabulary-words');

                // Call the function to populate antonym words
                populateVocabularyWords(antonymVocabularyWords, 'antonym-vocabulary-words');

                myModal.show();
            }
            else {
                ShowToastError(response.message);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            ShowToastError(jqXHR.responseJSON.message);
        });
}

//#endregion

function populateVocabularyWords(vocabularyWords, containerId) {
    const container = $(`#${containerId}`);
    container.empty(); // Clear previous content

    vocabularyWords.forEach(vocabularyWord => {
        const vocabularyWordItem = $('<label>').addClass('vocabulary-word-item btn btn-secondary rounded-pill').text(vocabularyWord.word);
        container.append(vocabularyWordItem);
    });
}

$(document).on('click', '#cancel-assign-vocabulary-word', function () {
    const truck_modal = document.querySelector('#modal-assign');
    const modal = bootstrap.Modal.getInstance(truck_modal);
    modal.hide();
    $('#form-assign-vocabulary-word :input[type="text"]').val('');
    $('#form-assign-vocabulary-word :input[type="date"]').val('');
});