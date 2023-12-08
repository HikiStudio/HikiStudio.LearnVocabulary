const commonRegularVerbs = [
  {
    "CommonRegularVerbID": 1,
    "OriginalV1": [
      "abide"
    ],
    "PastV2": [
      "abode",
      "abided"
    ],
    "PastParticipleV3": [
      "abode",
      "abided"
    ],
    "Definition": "lưu trú tại đâu"
  },
  {
    "CommonRegularVerbID": 2,
    "OriginalV1": [
      "arise"
    ],
    "PastV2": [
      "arose"
    ],
    "PastParticipleV3": [
      "arisen"
    ],
    "Definition": "phát sinh"
  },
  {
    "CommonRegularVerbID": 3,
    "OriginalV1": [
      "awake"
    ],
    "PastV2": [
      "awoke"
    ],
    "PastParticipleV3": [
      "awoken"
    ],
    "Definition": "thức dậy/đánh thức ai"
  },
  {
    "CommonRegularVerbID": 4,
    "OriginalV1": [
      "backslide"
    ],
    "PastV2": [
      "backslid"
    ],
    "PastParticipleV3": [
      "backslid",
      "backslidden"
    ],
    "Definition": "tái phạm"
  },
  {
    "CommonRegularVerbID": 5,
    "OriginalV1": [
      "be"
    ],
    "PastV2": [
      "was/were"
    ],
    "PastParticipleV3": [
      "been"
    ],
    "Definition": "là, thì, bị, ở"
  },
  {
    "CommonRegularVerbID": 6,
    "OriginalV1": [
      "bear"
    ],
    "PastV2": [
      "bore"
    ],
    "PastParticipleV3": [
      "born"
    ],
    "Definition": "chịu đựng/mang cái gì/đẻ con (người)"
  },
  {
    "CommonRegularVerbID": 7,
    "OriginalV1": [
      "beat"
    ],
    "PastV2": [
      "beat"
    ],
    "PastParticipleV3": [
      "beat",
      "beaten"
    ],
    "Definition": "đập/đánh"
  },
  {
    "CommonRegularVerbID": 8,
    "OriginalV1": [
      "become"
    ],
    "PastV2": [
      "became"
    ],
    "PastParticipleV3": [
      "become"
    ],
    "Definition": "trở thành"
  },
  {
    "CommonRegularVerbID": 9,
    "OriginalV1": [
      "befall"
    ],
    "PastV2": [
      "befell"
    ],
    "PastParticipleV3": [
      "befallen"
    ],
    "Definition": "(cái gì) xảy đến"
  },
  {
    "CommonRegularVerbID": 10,
    "OriginalV1": [
      "begin"
    ],
    "PastV2": [
      "began"
    ],
    "PastParticipleV3": [
      "begun"
    ],
    "Definition": "bắt đầu"
  },
  {
    "CommonRegularVerbID": 11,
    "OriginalV1": [
      "behold"
    ],
    "PastV2": [
      "beheld"
    ],
    "PastParticipleV3": [
      "beheld"
    ],
    "Definition": "nhìn ngắm"
  },
  {
    "CommonRegularVerbID": 12,
    "OriginalV1": [
      "bend"
    ],
    "PastV2": [
      "bent"
    ],
    "PastParticipleV3": [
      "bent"
    ],
    "Definition": "bẻ cong"
  },
  {
    "CommonRegularVerbID": 13,
    "OriginalV1": [
      "beset"
    ],
    "PastV2": [
      "beset"
    ],
    "PastParticipleV3": [
      "beset"
    ],
    "Definition": "ảnh hưởng/tác động xấu"
  },
  {
    "CommonRegularVerbID": 14,
    "OriginalV1": [
      "bespeak"
    ],
    "PastV2": [
      "bespoke"
    ],
    "PastParticipleV3": [
      "bespoken"
    ],
    "Definition": "thể hiện/cho thấy điều gì"
  },
  {
    "CommonRegularVerbID": 15,
    "OriginalV1": [
      "bet"
    ],
    "PastV2": [
      "bet"
    ],
    "PastParticipleV3": [
      "bet"
    ],
    "Definition": "cá cược"
  },
  {
    "CommonRegularVerbID": 16,
    "OriginalV1": [
      "bid"
    ],
    "PastV2": [
      "bid"
    ],
    "PastParticipleV3": [
      "bid"
    ],
    "Definition": "ra giá/đề xuất giá"
  },
  {
    "CommonRegularVerbID": 17,
    "OriginalV1": [
      "bind"
    ],
    "PastV2": [
      "bound"
    ],
    "PastParticipleV3": [
      "bound"
    ],
    "Definition": "trói, buộc"
  },
  {
    "CommonRegularVerbID": 18,
    "OriginalV1": [
      "bite"
    ],
    "PastV2": [
      "bit"
    ],
    "PastParticipleV3": [
      "bitten"
    ],
    "Definition": "cắn"
  },
  {
    "CommonRegularVerbID": 19,
    "OriginalV1": [
      "bleed"
    ],
    "PastV2": [
      "bled"
    ],
    "PastParticipleV3": [
      "bled"
    ],
    "Definition": "chảy máu"
  },
  {
    "CommonRegularVerbID": 20,
    "OriginalV1": [
      "blow"
    ],
    "PastV2": [
      "blew"
    ],
    "PastParticipleV3": [
      "blown"
    ],
    "Definition": "thổi"
  },
  {
    "CommonRegularVerbID": 21,
    "OriginalV1": [
      "break"
    ],
    "PastV2": [
      "broke"
    ],
    "PastParticipleV3": [
      "broken"
    ],
    "Definition": "làm vỡ/bể"
  },
  {
    "CommonRegularVerbID": 22,
    "OriginalV1": [
      "breed"
    ],
    "PastV2": [
      "bred"
    ],
    "PastParticipleV3": [
      "bred"
    ],
    "Definition": "giao phối và sinh con/nhân giống"
  },
  {
    "CommonRegularVerbID": 23,
    "OriginalV1": [
      "bring"
    ],
    "PastV2": [
      "brought"
    ],
    "PastParticipleV3": [
      "brought"
    ],
    "Definition": "mang tới"
  },
  {
    "CommonRegularVerbID": 24,
    "OriginalV1": [
      "broadcast"
    ],
    "PastV2": [
      "broadcast"
    ],
    "PastParticipleV3": [
      "broadcast"
    ],
    "Definition": "chiếu, phát chương trình"
  },
  {
    "CommonRegularVerbID": 25,
    "OriginalV1": [
      "browbeat"
    ],
    "PastV2": [
      "browbeat"
    ],
    "PastParticipleV3": [
      "browbeat",
      "browbeaten"
    ],
    "Definition": "đe dọa/hăm dọa ai để họ làm gì"
  },
  {
    "CommonRegularVerbID": 26,
    "OriginalV1": [
      "build"
    ],
    "PastV2": [
      "built"
    ],
    "PastParticipleV3": [
      "built"
    ],
    "Definition": "xây dựng"
  },
  {
    "CommonRegularVerbID": 27,
    "OriginalV1": [
      "burn"
    ],
    "PastV2": [
      "burnt",
      "burned"
    ],
    "PastParticipleV3": [
      "burnt",
      "burned"
    ],
    "Definition": "đốt/làm cháy"
  },
  {
    "CommonRegularVerbID": 28,
    "OriginalV1": [
      "burst"
    ],
    "PastV2": [
      "burst"
    ],
    "PastParticipleV3": [
      "burst"
    ],
    "Definition": "nổ tung/vỡ òa (khóc)"
  },
  {
    "CommonRegularVerbID": 29,
    "OriginalV1": [
      "bust"
    ],
    "PastV2": [
      "bust",
      "busted"
    ],
    "PastParticipleV3": [
      "bust",
      "busted"
    ],
    "Definition": "làm vỡ/bể"
  },
  {
    "CommonRegularVerbID": 30,
    "OriginalV1": [
      "buy"
    ],
    "PastV2": [
      "bought"
    ],
    "PastParticipleV3": [
      "bought"
    ],
    "Definition": "mua"
  },
  {
    "CommonRegularVerbID": 31,
    "OriginalV1": [
      "cast"
    ],
    "PastV2": [
      "cast"
    ],
    "PastParticipleV3": [
      "cast"
    ],
    "Definition": "tung/ném"
  },
  {
    "CommonRegularVerbID": 32,
    "OriginalV1": [
      "catch"
    ],
    "PastV2": [
      "caught"
    ],
    "PastParticipleV3": [
      "caught"
    ],
    "Definition": "bắt/bắt/chụp lấy"
  },
  {
    "CommonRegularVerbID": 33,
    "OriginalV1": [
      "chide"
    ],
    "PastV2": [
      "chid",
      "chided"
    ],
    "PastParticipleV3": [
      "chid",
      "chidden",
      "chided"
    ],
    "Definition": "mắng, chửi"
  },
  {
    "CommonRegularVerbID": 34,
    "OriginalV1": [
      "choose"
    ],
    "PastV2": [
      "chose"
    ],
    "PastParticipleV3": [
      "chosen"
    ],
    "Definition": "chọn"
  },
  {
    "CommonRegularVerbID": 35,
    "OriginalV1": [
      "cleave"
    ],
    "PastV2": [
      "clove",
      "cleft",
      "cleaved"
    ],
    "PastParticipleV3": [
      "cloven",
      "cleft",
      "cleaved"
    ],
    "Definition": "chẻ, tách hai"
  },
  {
    "CommonRegularVerbID": 36,
    "OriginalV1": [
      "cleave"
    ],
    "PastV2": [
      "clave"
    ],
    "PastParticipleV3": [
      "cleaved"
    ],
    "Definition": "dính chặt"
  },
  {
    "CommonRegularVerbID": 37,
    "OriginalV1": [
      "cling"
    ],
    "PastV2": [
      "clung"
    ],
    "PastParticipleV3": [
      "clung"
    ],
    "Definition": "bám/dính vào"
  },
  {
    "CommonRegularVerbID": 38,
    "OriginalV1": [
      "clothe"
    ],
    "PastV2": [
      "clothed",
      "clad"
    ],
    "PastParticipleV3": [
      "clothed",
      "clad"
    ],
    "Definition": "che phủ"
  },
  {
    "CommonRegularVerbID": 39,
    "OriginalV1": [
      "come"
    ],
    "PastV2": [
      "came"
    ],
    "PastParticipleV3": [
      "come"
    ],
    "Definition": "tới/đến/đi đến"
  },
  {
    "CommonRegularVerbID": 40,
    "OriginalV1": [
      "cost"
    ],
    "PastV2": [
      "cost"
    ],
    "PastParticipleV3": [
      "cost"
    ],
    "Definition": "có giá là bao nhiêu"
  },
  {
    "CommonRegularVerbID": 41,
    "OriginalV1": [
      "creep"
    ],
    "PastV2": [
      "crept"
    ],
    "PastParticipleV3": [
      "crept"
    ],
    "Definition": "di chuyển một cách lén lút"
  },
  {
    "CommonRegularVerbID": 42,
    "OriginalV1": [
      "crossbreed"
    ],
    "PastV2": [
      "crossbred"
    ],
    "PastParticipleV3": [
      "crossbred"
    ],
    "Definition": "cho lai giống"
  },
  {
    "CommonRegularVerbID": 43,
    "OriginalV1": [
      "crow"
    ],
    "PastV2": [
      "crew",
      "crewed"
    ],
    "PastParticipleV3": [
      "crowed"
    ],
    "Definition": "gáy (gà)"
  },
  {
    "CommonRegularVerbID": 44,
    "OriginalV1": [
      "cut"
    ],
    "PastV2": [
      "cut"
    ],
    "PastParticipleV3": [
      "cut"
    ],
    "Definition": "cắt"
  },
  {
    "CommonRegularVerbID": 45,
    "OriginalV1": [
      "daydream"
    ],
    "PastV2": [
      "daydreamt",
      "daydreamed"
    ],
    "PastParticipleV3": [
      "daydreamt",
      "daydreamed"
    ],
    "Definition": "suy nghĩ vẩn vơ/mơ mộng viển vông"
  },
  {
    "CommonRegularVerbID": 46,
    "OriginalV1": [
      "deal"
    ],
    "PastV2": [
      "dealt"
    ],
    "PastParticipleV3": [
      "dealt"
    ],
    "Definition": "chia bài/deal with sth: giải quyết cái gì"
  },
  {
    "CommonRegularVerbID": 47,
    "OriginalV1": [
      "dig"
    ],
    "PastV2": [
      "dug"
    ],
    "PastParticipleV3": [
      "dug"
    ],
    "Definition": "đào"
  },
  {
    "CommonRegularVerbID": 48,
    "OriginalV1": [
      "disprove"
    ],
    "PastV2": [
      "disproved"
    ],
    "PastParticipleV3": [
      "disproved",
      "disproven"
    ],
    "Definition": "bác bỏ"
  },
  {
    "CommonRegularVerbID": 49,
    "OriginalV1": [
      "dive"
    ],
    "PastV2": [
      "dovedived"
    ],
    "PastParticipleV3": [
      "dived"
    ],
    "Definition": "lặn"
  },
  {
    "CommonRegularVerbID": 50,
    "OriginalV1": [
      "do"
    ],
    "PastV2": [
      "did"
    ],
    "PastParticipleV3": [
      "done"
    ],
    "Definition": "làm"
  },
  {
    "CommonRegularVerbID": 51,
    "OriginalV1": [
      "draw"
    ],
    "PastV2": [
      "drew"
    ],
    "PastParticipleV3": [
      "drawn"
    ],
    "Definition": "vẽ"
  },
  {
    "CommonRegularVerbID": 52,
    "OriginalV1": [
      "dream"
    ],
    "PastV2": [
      "dreamt",
      "dreamed"
    ],
    "PastParticipleV3": [
      "dreamt",
      "dreamed"
    ],
    "Definition": "mơ ngủ/mơ ước"
  },
  {
    "CommonRegularVerbID": 53,
    "OriginalV1": [
      "drink"
    ],
    "PastV2": [
      "drank"
    ],
    "PastParticipleV3": [
      "drunk"
    ],
    "Definition": "uống"
  },
  {
    "CommonRegularVerbID": 54,
    "OriginalV1": [
      "drive"
    ],
    "PastV2": [
      "drove"
    ],
    "PastParticipleV3": [
      "driven"
    ],
    "Definition": "lái xe (bốn bánh)"
  },
  {
    "CommonRegularVerbID": 55,
    "OriginalV1": [
      "dwell"
    ],
    "PastV2": [
      "dwelt"
    ],
    "PastParticipleV3": [
      "dwelt"
    ],
    "Definition": "ở/trú ngụ (tại đâu)"
  },
  {
    "CommonRegularVerbID": 56,
    "OriginalV1": [
      "eat"
    ],
    "PastV2": [
      "ate"
    ],
    "PastParticipleV3": [
      "eaten"
    ],
    "Definition": "ăn"
  },
  {
    "CommonRegularVerbID": 57,
    "OriginalV1": [
      "fall"
    ],
    "PastV2": [
      "fell"
    ],
    "PastParticipleV3": [
      "fallen"
    ],
    "Definition": "ngã/rơi xuống"
  },
  {
    "CommonRegularVerbID": 58,
    "OriginalV1": [
      "feed"
    ],
    "PastV2": [
      "fed"
    ],
    "PastParticipleV3": [
      "fed"
    ],
    "Definition": "cho ăn/ăn/nuôi ăn"
  },
  {
    "CommonRegularVerbID": 59,
    "OriginalV1": [
      "feel"
    ],
    "PastV2": [
      "felt"
    ],
    "PastParticipleV3": [
      "felt"
    ],
    "Definition": "cảm thấy"
  },
  {
    "CommonRegularVerbID": 60,
    "OriginalV1": [
      "fight"
    ],
    "PastV2": [
      "fought"
    ],
    "PastParticipleV3": [
      "fought"
    ],
    "Definition": "chiến đấu/đấu tranh"
  },
  {
    "CommonRegularVerbID": 61,
    "OriginalV1": [
      "find"
    ],
    "PastV2": [
      "found"
    ],
    "PastParticipleV3": [
      "found"
    ],
    "Definition": "tìm kiếm/tìm thấy"
  },
  {
    "CommonRegularVerbID": 62,
    "OriginalV1": [
      "fit"
    ],
    "PastV2": [
      "fit"
    ],
    "PastParticipleV3": [
      "fit"
    ],
    "Definition": "(quần áo) vừa với ai"
  },
  {
    "CommonRegularVerbID": 63,
    "OriginalV1": [
      "flee"
    ],
    "PastV2": [
      "fled"
    ],
    "PastParticipleV3": [
      "fled"
    ],
    "Definition": "chạy trốn/chạy thoát"
  },
  {
    "CommonRegularVerbID": 64,
    "OriginalV1": [
      "fling"
    ],
    "PastV2": [
      "flung"
    ],
    "PastParticipleV3": [
      "flung"
    ],
    "Definition": "quăng/tung"
  },
  {
    "CommonRegularVerbID": 65,
    "OriginalV1": [
      "fly"
    ],
    "PastV2": [
      "flew"
    ],
    "PastParticipleV3": [
      "flown"
    ],
    "Definition": "bay"
  },
  {
    "CommonRegularVerbID": 66,
    "OriginalV1": [
      "forbid"
    ],
    "PastV2": [
      "forbade"
    ],
    "PastParticipleV3": [
      "forbidden"
    ],
    "Definition": "cấm"
  },
  {
    "CommonRegularVerbID": 67,
    "OriginalV1": [
      "forecast"
    ],
    "PastV2": [
      "forecast",
      "forecasted"
    ],
    "PastParticipleV3": [
      "forecast",
      "forecasted"
    ],
    "Definition": "dự đoán"
  },
  {
    "CommonRegularVerbID": 68,
    "OriginalV1": [
      "forego"
    ],
    "PastV2": [
      "forewent"
    ],
    "PastParticipleV3": [
      "foregone"
    ],
    "Definition": "quyết định không có/làm cái mà bạn luôn muốn có/làm"
  },
  {
    "CommonRegularVerbID": 69,
    "OriginalV1": [
      "foresee"
    ],
    "PastV2": [
      "foresaw"
    ],
    "PastParticipleV3": [
      "foreseen"
    ],
    "Definition": "thấy trước được cái gì"
  },
  {
    "CommonRegularVerbID": 70,
    "OriginalV1": [
      "foretell"
    ],
    "PastV2": [
      "foretold"
    ],
    "PastParticipleV3": [
      "foretold"
    ],
    "Definition": "tiên đoán/nói trước được cái gì"
  },
  {
    "CommonRegularVerbID": 71,
    "OriginalV1": [
      "forsake"
    ],
    "PastV2": [
      "forsook"
    ],
    "PastParticipleV3": [
      "forsaken"
    ],
    "Definition": "rũ bỏ/ruồng bỏ ai/cái gì"
  },
  {
    "CommonRegularVerbID": 72,
    "OriginalV1": [
      "freeze"
    ],
    "PastV2": [
      "froze"
    ],
    "PastParticipleV3": [
      "frozen"
    ],
    "Definition": "đông lại/làm đông ai/cái gì"
  },
  {
    "CommonRegularVerbID": 73,
    "OriginalV1": [
      "frostbite"
    ],
    "PastV2": [
      "frostbit"
    ],
    "PastParticipleV3": [
      "frostbitten"
    ],
    "Definition": "làm/gây bỏng lạnh"
  },
  {
    "CommonRegularVerbID": 74,
    "OriginalV1": [
      "get"
    ],
    "PastV2": [
      "got"
    ],
    "PastParticipleV3": [
      "gotten",
      "got"
    ],
    "Definition": "có được ai/cái gì"
  },
  {
    "CommonRegularVerbID": 75,
    "OriginalV1": [
      "gild"
    ],
    "PastV2": [
      "gilt",
      "gilded"
    ],
    "PastParticipleV3": [
      "gilt",
      "gilded"
    ],
    "Definition": "mạ vàng"
  },
  {
    "CommonRegularVerbID": 76,
    "OriginalV1": [
      "gird"
    ],
    "PastV2": [
      "girt",
      "girded"
    ],
    "PastParticipleV3": [
      "girt",
      "girded"
    ],
    "Definition": "đeo vào"
  },
  {
    "CommonRegularVerbID": 77,
    "OriginalV1": [
      "give"
    ],
    "PastV2": [
      "gave"
    ],
    "PastParticipleV3": [
      "given"
    ],
    "Definition": "đưa cho/cho"
  },
  {
    "CommonRegularVerbID": 78,
    "OriginalV1": [
      "go"
    ],
    "PastV2": [
      "went"
    ],
    "PastParticipleV3": [
      "gone"
    ],
    "Definition": "đi"
  },
  {
    "CommonRegularVerbID": 79,
    "OriginalV1": [
      "grow"
    ],
    "PastV2": [
      "grew"
    ],
    "PastParticipleV3": [
      "grown"
    ],
    "Definition": "mọc lên/ lớn lên/trồng"
  },
  {
    "CommonRegularVerbID": 80,
    "OriginalV1": [
      "hand-feed"
    ],
    "PastV2": [
      "hand-fed"
    ],
    "PastParticipleV3": [
      "hand-fed"
    ],
    "Definition": "cho ăn bằng tay"
  },
  {
    "CommonRegularVerbID": 81,
    "OriginalV1": [
      "handwrite"
    ],
    "PastV2": [
      "handwrote"
    ],
    "PastParticipleV3": [
      "handwritten"
    ],
    "Definition": "viết tay"
  },
  {
    "CommonRegularVerbID": 82,
    "OriginalV1": [
      "hang"
    ],
    "PastV2": [
      "hung"
    ],
    "PastParticipleV3": [
      "hung"
    ],
    "Definition": "treo lên/máng lên"
  },
  {
    "CommonRegularVerbID": 83,
    "OriginalV1": [
      "have"
    ],
    "PastV2": [
      "had"
    ],
    "PastParticipleV3": [
      "had"
    ],
    "Definition": "có/ăn cái gì"
  },
  {
    "CommonRegularVerbID": 84,
    "OriginalV1": [
      "hear"
    ],
    "PastV2": [
      "heard"
    ],
    "PastParticipleV3": [
      "heard"
    ],
    "Definition": "nghe"
  },
  {
    "CommonRegularVerbID": 85,
    "OriginalV1": [
      "heave"
    ],
    "PastV2": [
      "hove",
      "heaved"
    ],
    "PastParticipleV3": [
      "hove",
      "heaved"
    ],
    "Definition": "trục lên"
  },
  {
    "CommonRegularVerbID": 86,
    "OriginalV1": [
      "hew"
    ],
    "PastV2": [
      "hewed"
    ],
    "PastParticipleV3": [
      "hewn",
      "hewed"
    ],
    "Definition": "chặt, đốn"
  },
  {
    "CommonRegularVerbID": 87,
    "OriginalV1": [
      "hide"
    ],
    "PastV2": [
      "hid"
    ],
    "PastParticipleV3": [
      "hidden"
    ],
    "Definition": "giấu, trốn, nấp"
  },
  {
    "CommonRegularVerbID": 88,
    "OriginalV1": [
      "hit"
    ],
    "PastV2": [
      "hit"
    ],
    "PastParticipleV3": [
      "hit"
    ],
    "Definition": "đụng"
  },
  {
    "CommonRegularVerbID": 89,
    "OriginalV1": [
      "hurt"
    ],
    "PastV2": [
      "hurt"
    ],
    "PastParticipleV3": [
      "hurt"
    ],
    "Definition": "làm đau"
  },
  {
    "CommonRegularVerbID": 90,
    "OriginalV1": [
      "inbreed"
    ],
    "PastV2": [
      "inbred"
    ],
    "PastParticipleV3": [
      "inbred"
    ],
    "Definition": "lai giống cận huyết"
  },
  {
    "CommonRegularVerbID": 91,
    "OriginalV1": [
      "inlay"
    ],
    "PastV2": [
      "inlaid"
    ],
    "PastParticipleV3": [
      "inlaid"
    ],
    "Definition": "cẩn, khảm"
  },
  {
    "CommonRegularVerbID": 92,
    "OriginalV1": [
      "input"
    ],
    "PastV2": [
      "input"
    ],
    "PastParticipleV3": [
      "input"
    ],
    "Definition": "đưa vào"
  },
  {
    "CommonRegularVerbID": 93,
    "OriginalV1": [
      "inset"
    ],
    "PastV2": [
      "inset"
    ],
    "PastParticipleV3": [
      "inset"
    ],
    "Definition": "dát, ghép"
  },
  {
    "CommonRegularVerbID": 94,
    "OriginalV1": [
      "interbreed"
    ],
    "PastV2": [
      "interbred"
    ],
    "PastParticipleV3": [
      "interbred"
    ],
    "Definition": "giao phối, lai giống"
  },
  {
    "CommonRegularVerbID": 95,
    "OriginalV1": [
      "interweave"
    ],
    "PastV2": [
      "interwove",
      "interweaved"
    ],
    "PastParticipleV3": [
      "interwoven",
      "interweaved"
    ],
    "Definition": "trộn lẫn, xen lẫn"
  },
  {
    "CommonRegularVerbID": 96,
    "OriginalV1": [
      "interwind"
    ],
    "PastV2": [
      "interwound"
    ],
    "PastParticipleV3": [
      "interwound"
    ],
    "Definition": "cuộn vào, quấn vào"
  },
  {
    "CommonRegularVerbID": 97,
    "OriginalV1": [
      "jerry-build"
    ],
    "PastV2": [
      "jerry-built"
    ],
    "PastParticipleV3": [
      "jerry-built"
    ],
    "Definition": "xây dựng cẩu thả"
  },
  {
    "CommonRegularVerbID": 98,
    "OriginalV1": [
      "keep"
    ],
    "PastV2": [
      "kept"
    ],
    "PastParticipleV3": [
      "kept"
    ],
    "Definition": "giữ"
  },
  {
    "CommonRegularVerbID": 99,
    "OriginalV1": [
      "kneel"
    ],
    "PastV2": [
      "knelt",
      "kneeled"
    ],
    "PastParticipleV3": [
      "knelt",
      "kneeled"
    ],
    "Definition": "quỳ"
  },
  {
    "CommonRegularVerbID": 100,
    "OriginalV1": [
      "knit"
    ],
    "PastV2": [
      "knit",
      "knitted"
    ],
    "PastParticipleV3": [
      "knit",
      "knitted"
    ],
    "Definition": "đan"
  },
  {
    "CommonRegularVerbID": 101,
    "OriginalV1": [
      "know"
    ],
    "PastV2": [
      "knew"
    ],
    "PastParticipleV3": [
      "known"
    ],
    "Definition": "biết, quen biết"
  },
  {
    "CommonRegularVerbID": 102,
    "OriginalV1": [
      "lay"
    ],
    "PastV2": [
      "laid"
    ],
    "PastParticipleV3": [
      "laid"
    ],
    "Definition": "đặt, để"
  },
  {
    "CommonRegularVerbID": 103,
    "OriginalV1": [
      "lead"
    ],
    "PastV2": [
      "led"
    ],
    "PastParticipleV3": [
      "led"
    ],
    "Definition": "dẫn dắt, lãnh đạo"
  },
  {
    "CommonRegularVerbID": 104,
    "OriginalV1": [
      "lean"
    ],
    "PastV2": [
      "leaned",
      "leant"
    ],
    "PastParticipleV3": [
      "leaned",
      "leant"
    ],
    "Definition": "dựa, tựa"
  },
  {
    "CommonRegularVerbID": 105,
    "OriginalV1": [
      "leap"
    ],
    "PastV2": [
      "leapt"
    ],
    "PastParticipleV3": [
      "leapt"
    ],
    "Definition": "nhảy, nhảy qua"
  },
  {
    "CommonRegularVerbID": 106,
    "OriginalV1": [
      "learn"
    ],
    "PastV2": [
      "learnt",
      "learned"
    ],
    "PastParticipleV3": [
      "learnt",
      "learned"
    ],
    "Definition": "học, được biết"
  },
  {
    "CommonRegularVerbID": 107,
    "OriginalV1": [
      "leave"
    ],
    "PastV2": [
      "left"
    ],
    "PastParticipleV3": [
      "left"
    ],
    "Definition": "ra đi, để lại"
  },
  {
    "CommonRegularVerbID": 108,
    "OriginalV1": [
      "lend"
    ],
    "PastV2": [
      "lent"
    ],
    "PastParticipleV3": [
      "lent"
    ],
    "Definition": "cho mượn"
  },
  {
    "CommonRegularVerbID": 109,
    "OriginalV1": [
      "let"
    ],
    "PastV2": [
      "let"
    ],
    "PastParticipleV3": [
      "let"
    ],
    "Definition": "cho phép, để cho"
  },
  {
    "CommonRegularVerbID": 110,
    "OriginalV1": [
      "lie"
    ],
    "PastV2": [
      "lay"
    ],
    "PastParticipleV3": [
      "lain"
    ],
    "Definition": "nằm"
  },
  {
    "CommonRegularVerbID": 111,
    "OriginalV1": [
      "light"
    ],
    "PastV2": [
      "litlighted"
    ],
    "PastParticipleV3": [
      "litlighted"
    ],
    "Definition": "thắp sáng"
  },
  {
    "CommonRegularVerbID": 112,
    "OriginalV1": [
      "lip-read"
    ],
    "PastV2": [
      "lip-read"
    ],
    "PastParticipleV3": [
      "lip-read"
    ],
    "Definition": "mấp máy môi"
  },
  {
    "CommonRegularVerbID": 113,
    "OriginalV1": [
      "lose"
    ],
    "PastV2": [
      "lost"
    ],
    "PastParticipleV3": [
      "lost"
    ],
    "Definition": "làm mất, mất"
  },
  {
    "CommonRegularVerbID": 114,
    "OriginalV1": [
      "make"
    ],
    "PastV2": [
      "made"
    ],
    "PastParticipleV3": [
      "made"
    ],
    "Definition": "chế tạo, sản xuất"
  },
  {
    "CommonRegularVerbID": 115,
    "OriginalV1": [
      "mean"
    ],
    "PastV2": [
      "meant"
    ],
    "PastParticipleV3": [
      "meant"
    ],
    "Definition": "có nghĩa là"
  },
  {
    "CommonRegularVerbID": 116,
    "OriginalV1": [
      "meet"
    ],
    "PastV2": [
      "met"
    ],
    "PastParticipleV3": [
      "met"
    ],
    "Definition": "gặp mặt"
  },
  {
    "CommonRegularVerbID": 117,
    "OriginalV1": [
      "miscast"
    ],
    "PastV2": [
      "miscast"
    ],
    "PastParticipleV3": [
      "miscast"
    ],
    "Definition": "chọn vai đóng không hợp"
  },
  {
    "CommonRegularVerbID": 118,
    "OriginalV1": [
      "misdeal"
    ],
    "PastV2": [
      "misdealt"
    ],
    "PastParticipleV3": [
      "misdealt"
    ],
    "Definition": "chia lộn bài, chia bài sai"
  },
  {
    "CommonRegularVerbID": 119,
    "OriginalV1": [
      "misdo"
    ],
    "PastV2": [
      "misdid"
    ],
    "PastParticipleV3": [
      "misdone"
    ],
    "Definition": "phạm lỗi"
  },
  {
    "CommonRegularVerbID": 120,
    "OriginalV1": [
      "mishear"
    ],
    "PastV2": [
      "misheard"
    ],
    "PastParticipleV3": [
      "misheard"
    ],
    "Definition": "nghe nhầm"
  },
  {
    "CommonRegularVerbID": 121,
    "OriginalV1": [
      "mislay"
    ],
    "PastV2": [
      "mislaid"
    ],
    "PastParticipleV3": [
      "mislaid"
    ],
    "Definition": "để lạc mất"
  },
  {
    "CommonRegularVerbID": 122,
    "OriginalV1": [
      "mislead"
    ],
    "PastV2": [
      "misled"
    ],
    "PastParticipleV3": [
      "misled"
    ],
    "Definition": "làm lạc đường"
  },
  {
    "CommonRegularVerbID": 123,
    "OriginalV1": [
      "mislearn"
    ],
    "PastV2": [
      "mislearned",
      "mislearnt"
    ],
    "PastParticipleV3": [
      "mislearned",
      "mislearnt"
    ],
    "Definition": "học nhầm"
  },
  {
    "CommonRegularVerbID": 124,
    "OriginalV1": [
      "misread"
    ],
    "PastV2": [
      "misread"
    ],
    "PastParticipleV3": [
      "misread"
    ],
    "Definition": "đọc sai"
  },
  {
    "CommonRegularVerbID": 125,
    "OriginalV1": [
      "misset"
    ],
    "PastV2": [
      "misset"
    ],
    "PastParticipleV3": [
      "misset"
    ],
    "Definition": "đặt sai chỗ"
  },
  {
    "CommonRegularVerbID": 126,
    "OriginalV1": [
      "misspeak"
    ],
    "PastV2": [
      "misspoke"
    ],
    "PastParticipleV3": [
      "misspoken"
    ],
    "Definition": "nói sai"
  },
  {
    "CommonRegularVerbID": 127,
    "OriginalV1": [
      "misspell"
    ],
    "PastV2": [
      "misspelt"
    ],
    "PastParticipleV3": [
      "misspelt"
    ],
    "Definition": "viết sai chính tả"
  },
  {
    "CommonRegularVerbID": 128,
    "OriginalV1": [
      "misspend"
    ],
    "PastV2": [
      "misspent"
    ],
    "PastParticipleV3": [
      "misspent"
    ],
    "Definition": "tiêu phí, bỏ phí"
  },
  {
    "CommonRegularVerbID": 129,
    "OriginalV1": [
      "mistake"
    ],
    "PastV2": [
      "mistook"
    ],
    "PastParticipleV3": [
      "mistaken"
    ],
    "Definition": "phạm lỗi, lầm lẫn"
  },
  {
    "CommonRegularVerbID": 130,
    "OriginalV1": [
      "misteach"
    ],
    "PastV2": [
      "mistaught"
    ],
    "PastParticipleV3": [
      "mistaught"
    ],
    "Definition": "dạy sai"
  },
  {
    "CommonRegularVerbID": 131,
    "OriginalV1": [
      "misunderstand"
    ],
    "PastV2": [
      "misunderstood"
    ],
    "PastParticipleV3": [
      "misunderstood"
    ],
    "Definition": "hiểu lầm"
  },
  {
    "CommonRegularVerbID": 132,
    "OriginalV1": [
      "miswrite"
    ],
    "PastV2": [
      "miswrote"
    ],
    "PastParticipleV3": [
      "miswritten"
    ],
    "Definition": "viết sai"
  },
  {
    "CommonRegularVerbID": 133,
    "OriginalV1": [
      "mow"
    ],
    "PastV2": [
      "mowed"
    ],
    "PastParticipleV3": [
      "mown",
      "mowed"
    ],
    "Definition": "cắt cỏ"
  },
  {
    "CommonRegularVerbID": 134,
    "OriginalV1": [
      "offset"
    ],
    "PastV2": [
      "offset"
    ],
    "PastParticipleV3": [
      "offset"
    ],
    "Definition": "đền bù"
  },
  {
    "CommonRegularVerbID": 135,
    "OriginalV1": [
      "outbid"
    ],
    "PastV2": [
      "outbid"
    ],
    "PastParticipleV3": [
      "outbid"
    ],
    "Definition": "trả hơn giá"
  },
  {
    "CommonRegularVerbID": 136,
    "OriginalV1": [
      "outbreed"
    ],
    "PastV2": [
      "outbred"
    ],
    "PastParticipleV3": [
      "outbred"
    ],
    "Definition": "giao phối xa"
  },
  {
    "CommonRegularVerbID": 137,
    "OriginalV1": [
      "outdo"
    ],
    "PastV2": [
      "outdid"
    ],
    "PastParticipleV3": [
      "outdone"
    ],
    "Definition": "làm giỏi hơn"
  },
  {
    "CommonRegularVerbID": 138,
    "OriginalV1": [
      "outdraw"
    ],
    "PastV2": [
      "outdrew"
    ],
    "PastParticipleV3": [
      "outdrawn"
    ],
    "Definition": "rút súng ra nhanh hơn"
  },
  {
    "CommonRegularVerbID": 139,
    "OriginalV1": [
      "outdrink"
    ],
    "PastV2": [
      "outdrank"
    ],
    "PastParticipleV3": [
      "outdrunk"
    ],
    "Definition": "uống quá chén"
  },
  {
    "CommonRegularVerbID": 140,
    "OriginalV1": [
      "outdrive"
    ],
    "PastV2": [
      "outdrove"
    ],
    "PastParticipleV3": [
      "outdriven"
    ],
    "Definition": "lái nhanh hơn"
  },
  {
    "CommonRegularVerbID": 141,
    "OriginalV1": [
      "outfight"
    ],
    "PastV2": [
      "outfought"
    ],
    "PastParticipleV3": [
      "outfought"
    ],
    "Definition": "đánh giỏi hơn"
  },
  {
    "CommonRegularVerbID": 142,
    "OriginalV1": [
      "outfly"
    ],
    "PastV2": [
      "outflew"
    ],
    "PastParticipleV3": [
      "outflown"
    ],
    "Definition": "bay cao/xa hơn"
  },
  {
    "CommonRegularVerbID": 143,
    "OriginalV1": [
      "outgrow"
    ],
    "PastV2": [
      "outgrew"
    ],
    "PastParticipleV3": [
      "outgrown"
    ],
    "Definition": "lớn nhanh hơn"
  },
  {
    "CommonRegularVerbID": 144,
    "OriginalV1": [
      "outleap"
    ],
    "PastV2": [
      "outleaped",
      "outleapt"
    ],
    "PastParticipleV3": [
      "outleaped",
      "outleapt"
    ],
    "Definition": "nhảy cao/xa hơn"
  },
  {
    "CommonRegularVerbID": 145,
    "OriginalV1": [
      "output"
    ],
    "PastV2": [
      "output"
    ],
    "PastParticipleV3": [
      "output"
    ],
    "Definition": "cho ra (dữ kiện)"
  },
  {
    "CommonRegularVerbID": 146,
    "OriginalV1": [
      "outride"
    ],
    "PastV2": [
      "outrode"
    ],
    "PastParticipleV3": [
      "outridden"
    ],
    "Definition": "cưỡi ngựa giỏi hơn"
  },
  {
    "CommonRegularVerbID": 147,
    "OriginalV1": [
      "outrun"
    ],
    "PastV2": [
      "outran"
    ],
    "PastParticipleV3": [
      "outrun"
    ],
    "Definition": "chạy nhanh hơn, vượt giá"
  },
  {
    "CommonRegularVerbID": 148,
    "OriginalV1": [
      "outsell"
    ],
    "PastV2": [
      "outsold"
    ],
    "PastParticipleV3": [
      "outsold"
    ],
    "Definition": "bán nhanh hơn"
  },
  {
    "CommonRegularVerbID": 149,
    "OriginalV1": [
      "outshine"
    ],
    "PastV2": [
      "outshined",
      "outshone"
    ],
    "PastParticipleV3": [
      "outshined",
      "outshone"
    ],
    "Definition": "sáng hơn, rạng rỡ hơn"
  },
  {
    "CommonRegularVerbID": 150,
    "OriginalV1": [
      "outshoot"
    ],
    "PastV2": [
      "outshot"
    ],
    "PastParticipleV3": [
      "outshot"
    ],
    "Definition": "bắn giỏi hơn, nảy mầm, mọc"
  },
  {
    "CommonRegularVerbID": 151,
    "OriginalV1": [
      "outsing"
    ],
    "PastV2": [
      "outsang"
    ],
    "PastParticipleV3": [
      "outsung"
    ],
    "Definition": "hát hay hơn"
  },
  {
    "CommonRegularVerbID": 152,
    "OriginalV1": [
      "outsit"
    ],
    "PastV2": [
      "outsat"
    ],
    "PastParticipleV3": [
      "outsat"
    ],
    "Definition": "ngồi lâu hơn"
  },
  {
    "CommonRegularVerbID": 153,
    "OriginalV1": [
      "outsleep"
    ],
    "PastV2": [
      "outslept"
    ],
    "PastParticipleV3": [
      "outslept"
    ],
    "Definition": "ngủ lâu/muộn hơn"
  },
  {
    "CommonRegularVerbID": 154,
    "OriginalV1": [
      "outsmell"
    ],
    "PastV2": [
      "outsmelled",
      "outsmelt"
    ],
    "PastParticipleV3": [
      "outsmelled",
      "outsmelt"
    ],
    "Definition": "khám phá, đánh hơi, sặc mùi"
  },
  {
    "CommonRegularVerbID": 155,
    "OriginalV1": [
      "outspeak"
    ],
    "PastV2": [
      "outspoke"
    ],
    "PastParticipleV3": [
      "outspoken"
    ],
    "Definition": "nói nhiều/dài/to hơn"
  },
  {
    "CommonRegularVerbID": 156,
    "OriginalV1": [
      "outspeed"
    ],
    "PastV2": [
      "outsped"
    ],
    "PastParticipleV3": [
      "outsped"
    ],
    "Definition": "đi/chạy nhanh hơn"
  },
  {
    "CommonRegularVerbID": 157,
    "OriginalV1": [
      "outspend"
    ],
    "PastV2": [
      "outspent"
    ],
    "PastParticipleV3": [
      "outspent"
    ],
    "Definition": "tiêu tiền nhiều hơn"
  },
  {
    "CommonRegularVerbID": 158,
    "OriginalV1": [
      "outswear"
    ],
    "PastV2": [
      "outswore"
    ],
    "PastParticipleV3": [
      "outsworn"
    ],
    "Definition": "nguyền rủa nhiều hơn"
  },
  {
    "CommonRegularVerbID": 159,
    "OriginalV1": [
      "outswim"
    ],
    "PastV2": [
      "outswam"
    ],
    "PastParticipleV3": [
      "outswam"
    ],
    "Definition": "bơi giỏi hơn"
  },
  {
    "CommonRegularVerbID": 160,
    "OriginalV1": [
      "outthink"
    ],
    "PastV2": [
      "outthought"
    ],
    "PastParticipleV3": [
      "outthought"
    ],
    "Definition": "suy nghĩ nhanh hơn"
  },
  {
    "CommonRegularVerbID": 161,
    "OriginalV1": [
      "outthrow"
    ],
    "PastV2": [
      "outthrew"
    ],
    "PastParticipleV3": [
      "outthrown"
    ],
    "Definition": "ném nhanh hơn"
  },
  {
    "CommonRegularVerbID": 162,
    "OriginalV1": [
      "outwrite"
    ],
    "PastV2": [
      "outwrote"
    ],
    "PastParticipleV3": [
      "outwritten"
    ],
    "Definition": "viết nhanh hơn"
  },
  {
    "CommonRegularVerbID": 163,
    "OriginalV1": [
      "overbid"
    ],
    "PastV2": [
      "overbid"
    ],
    "PastParticipleV3": [
      "overbid"
    ],
    "Definition": "bỏ thầu cao hơn"
  },
  {
    "CommonRegularVerbID": 164,
    "OriginalV1": [
      "overbreed"
    ],
    "PastV2": [
      "overbred"
    ],
    "PastParticipleV3": [
      "overbred"
    ],
    "Definition": "nuôi quá nhiều"
  },
  {
    "CommonRegularVerbID": 165,
    "OriginalV1": [
      "overbuild"
    ],
    "PastV2": [
      "overbuilt"
    ],
    "PastParticipleV3": [
      "overbuilt"
    ],
    "Definition": "xây quá nhiều"
  },
  {
    "CommonRegularVerbID": 166,
    "OriginalV1": [
      "overbuy"
    ],
    "PastV2": [
      "overbought"
    ],
    "PastParticipleV3": [
      "overbought"
    ],
    "Definition": "mua quá nhiều"
  },
  {
    "CommonRegularVerbID": 167,
    "OriginalV1": [
      "overcome"
    ],
    "PastV2": [
      "overcame"
    ],
    "PastParticipleV3": [
      "overcome"
    ],
    "Definition": "khắc phục"
  },
  {
    "CommonRegularVerbID": 168,
    "OriginalV1": [
      "overdo"
    ],
    "PastV2": [
      "overdid"
    ],
    "PastParticipleV3": [
      "overdone"
    ],
    "Definition": "dùng quá mức, làm quá"
  },
  {
    "CommonRegularVerbID": 169,
    "OriginalV1": [
      "overdraw"
    ],
    "PastV2": [
      "overdraw"
    ],
    "PastParticipleV3": [
      "overdrawn"
    ],
    "Definition": "rút quá số tiền, phóng đại"
  },
  {
    "CommonRegularVerbID": 170,
    "OriginalV1": [
      "overdrink"
    ],
    "PastV2": [
      "overdrank"
    ],
    "PastParticipleV3": [
      "overdrunk"
    ],
    "Definition": "uống quá nhiều"
  },
  {
    "CommonRegularVerbID": 171,
    "OriginalV1": [
      "overeat"
    ],
    "PastV2": [
      "overate"
    ],
    "PastParticipleV3": [
      "overeaten"
    ],
    "Definition": "ăn quá nhiều"
  },
  {
    "CommonRegularVerbID": 172,
    "OriginalV1": [
      "overfeed"
    ],
    "PastV2": [
      "overfed"
    ],
    "PastParticipleV3": [
      "overfed"
    ],
    "Definition": "cho ăn quá mức"
  },
  {
    "CommonRegularVerbID": 173,
    "OriginalV1": [
      "overfly"
    ],
    "PastV2": [
      "overflew"
    ],
    "PastParticipleV3": [
      "overflown"
    ],
    "Definition": "bay qua"
  },
  {
    "CommonRegularVerbID": 174,
    "OriginalV1": [
      "overhang"
    ],
    "PastV2": [
      "overhung"
    ],
    "PastParticipleV3": [
      "overhung"
    ],
    "Definition": "nhô lên trên, treo lơ lửng"
  },
  {
    "CommonRegularVerbID": 175,
    "OriginalV1": [
      "overhear"
    ],
    "PastV2": [
      "overheard"
    ],
    "PastParticipleV3": [
      "overheard"
    ],
    "Definition": "nghe trộm"
  },
  {
    "CommonRegularVerbID": 176,
    "OriginalV1": [
      "overlay"
    ],
    "PastV2": [
      "overlaid"
    ],
    "PastParticipleV3": [
      "overlaid"
    ],
    "Definition": "phủ lên"
  },
  {
    "CommonRegularVerbID": 177,
    "OriginalV1": [
      "overpay"
    ],
    "PastV2": [
      "overpaid"
    ],
    "PastParticipleV3": [
      "overpaid"
    ],
    "Definition": "trả quá tiền"
  },
  {
    "CommonRegularVerbID": 178,
    "OriginalV1": [
      "override"
    ],
    "PastV2": [
      "overrode"
    ],
    "PastParticipleV3": [
      "overridden"
    ],
    "Definition": "lạm quyền"
  },
  {
    "CommonRegularVerbID": 179,
    "OriginalV1": [
      "overrun"
    ],
    "PastV2": [
      "overran"
    ],
    "PastParticipleV3": [
      "overrun"
    ],
    "Definition": "tràn ngập"
  },
  {
    "CommonRegularVerbID": 180,
    "OriginalV1": [
      "oversee"
    ],
    "PastV2": [
      "oversaw"
    ],
    "PastParticipleV3": [
      "overseen"
    ],
    "Definition": "trông nom"
  },
  {
    "CommonRegularVerbID": 181,
    "OriginalV1": [
      "oversell"
    ],
    "PastV2": [
      "oversold"
    ],
    "PastParticipleV3": [
      "oversold"
    ],
    "Definition": "bán quá mức"
  },
  {
    "CommonRegularVerbID": 182,
    "OriginalV1": [
      "oversew"
    ],
    "PastV2": [
      "oversewed"
    ],
    "PastParticipleV3": [
      "oversewn",
      "oversewed"
    ],
    "Definition": "may nối vắt"
  },
  {
    "CommonRegularVerbID": 183,
    "OriginalV1": [
      "overshoot"
    ],
    "PastV2": [
      "overshot"
    ],
    "PastParticipleV3": [
      "overshot"
    ],
    "Definition": "đi quá đích"
  },
  {
    "CommonRegularVerbID": 184,
    "OriginalV1": [
      "oversleep"
    ],
    "PastV2": [
      "overslept"
    ],
    "PastParticipleV3": [
      "overslept"
    ],
    "Definition": "ngủ quên"
  },
  {
    "CommonRegularVerbID": 185,
    "OriginalV1": [
      "overspeak"
    ],
    "PastV2": [
      "overspoke"
    ],
    "PastParticipleV3": [
      "overspoken"
    ],
    "Definition": "nói quá nhiều, nói lấn át"
  },
  {
    "CommonRegularVerbID": 186,
    "OriginalV1": [
      "overspend"
    ],
    "PastV2": [
      "overspent"
    ],
    "PastParticipleV3": [
      "overspent"
    ],
    "Definition": "tiêu quá lố"
  },
  {
    "CommonRegularVerbID": 187,
    "OriginalV1": [
      "overspill"
    ],
    "PastV2": [
      "overspilled",
      "overspilt"
    ],
    "PastParticipleV3": [
      "overspilled",
      "overspilt"
    ],
    "Definition": "đổ, làm tràn"
  },
  {
    "CommonRegularVerbID": 188,
    "OriginalV1": [
      "overtake"
    ],
    "PastV2": [
      "overtook"
    ],
    "PastParticipleV3": [
      "overtook"
    ],
    "Definition": "đuổi bắt kịp"
  },
  {
    "CommonRegularVerbID": 189,
    "OriginalV1": [
      "overthink"
    ],
    "PastV2": [
      "overthought"
    ],
    "PastParticipleV3": [
      "overthought"
    ],
    "Definition": "tính trước nhiều quá"
  },
  {
    "CommonRegularVerbID": 190,
    "OriginalV1": [
      "overthrow"
    ],
    "PastV2": [
      "overthrew"
    ],
    "PastParticipleV3": [
      "overthrown"
    ],
    "Definition": "lật đổ"
  },
  {
    "CommonRegularVerbID": 191,
    "OriginalV1": [
      "overwind"
    ],
    "PastV2": [
      "overwound"
    ],
    "PastParticipleV3": [
      "overwound"
    ],
    "Definition": "lên dây (đồng hồ) quá chặt"
  },
  {
    "CommonRegularVerbID": 192,
    "OriginalV1": [
      "overwrite"
    ],
    "PastV2": [
      "overwrote"
    ],
    "PastParticipleV3": [
      "overwritten"
    ],
    "Definition": "viết dài quá, viết đè lên"
  },
  {
    "CommonRegularVerbID": 193,
    "OriginalV1": [
      "partake"
    ],
    "PastV2": [
      "partook"
    ],
    "PastParticipleV3": [
      "partaken"
    ],
    "Definition": "tham gia, dự phần"
  },
  {
    "CommonRegularVerbID": 194,
    "OriginalV1": [
      "pay"
    ],
    "PastV2": [
      "paid"
    ],
    "PastParticipleV3": [
      "paid"
    ],
    "Definition": "trả (tiền)"
  },
  {
    "CommonRegularVerbID": 195,
    "OriginalV1": [
      "plead"
    ],
    "PastV2": [
      "pleaded",
      "pled"
    ],
    "PastParticipleV3": [
      "pleaded",
      "pled"
    ],
    "Definition": "bào chữa, biện hộ"
  },
  {
    "CommonRegularVerbID": 196,
    "OriginalV1": [
      "prebuild"
    ],
    "PastV2": [
      "prebuilt"
    ],
    "PastParticipleV3": [
      "prebuilt"
    ],
    "Definition": "làm nhà tiền chế"
  },
  {
    "CommonRegularVerbID": 197,
    "OriginalV1": [
      "predo"
    ],
    "PastV2": [
      "predid"
    ],
    "PastParticipleV3": [
      "predone"
    ],
    "Definition": "làm trước"
  },
  {
    "CommonRegularVerbID": 198,
    "OriginalV1": [
      "premake"
    ],
    "PastV2": [
      "premade"
    ],
    "PastParticipleV3": [
      "premade"
    ],
    "Definition": "làm trước"
  },
  {
    "CommonRegularVerbID": 199,
    "OriginalV1": [
      "prepay"
    ],
    "PastV2": [
      "prepaid"
    ],
    "PastParticipleV3": [
      "prepaid"
    ],
    "Definition": "trả trước"
  },
  {
    "CommonRegularVerbID": 200,
    "OriginalV1": [
      "presell"
    ],
    "PastV2": [
      "presold"
    ],
    "PastParticipleV3": [
      "presold"
    ],
    "Definition": "bán trước thời gian rao báo"
  },
  {
    "CommonRegularVerbID": 201,
    "OriginalV1": [
      "preset"
    ],
    "PastV2": [
      "preset"
    ],
    "PastParticipleV3": [
      "preset"
    ],
    "Definition": "thiết lập sẵn, cài đặt sẵn"
  },
  {
    "CommonRegularVerbID": 202,
    "OriginalV1": [
      "preshrink"
    ],
    "PastV2": [
      "preshrank"
    ],
    "PastParticipleV3": [
      "preshrunk"
    ],
    "Definition": "ngâm cho vải co trước khi may"
  },
  {
    "CommonRegularVerbID": 203,
    "OriginalV1": [
      "proofread"
    ],
    "PastV2": [
      "proofread"
    ],
    "PastParticipleV3": [
      "proofread"
    ],
    "Definition": "đọc bản thảo trước khi in"
  },
  {
    "CommonRegularVerbID": 204,
    "OriginalV1": [
      "prove"
    ],
    "PastV2": [
      "proved"
    ],
    "PastParticipleV3": [
      "proven",
      "proved"
    ],
    "Definition": "chứng minh"
  },
  {
    "CommonRegularVerbID": 205,
    "OriginalV1": [
      "put"
    ],
    "PastV2": [
      "put"
    ],
    "PastParticipleV3": [
      "put"
    ],
    "Definition": "đặt, để"
  },
  {
    "CommonRegularVerbID": 206,
    "OriginalV1": [
      "quick-freeze"
    ],
    "PastV2": [
      "quick-froze"
    ],
    "PastParticipleV3": [
      "quick-frozen"
    ],
    "Definition": "kết đông nhanh"
  },
  {
    "CommonRegularVerbID": 207,
    "OriginalV1": [
      "quit"
    ],
    "PastV2": [
      "quitquitted"
    ],
    "PastParticipleV3": [
      "quitquitted"
    ],
    "Definition": "bỏ"
  },
  {
    "CommonRegularVerbID": 208,
    "OriginalV1": [
      "read"
    ],
    "PastV2": [
      "read"
    ],
    "PastParticipleV3": [
      "read"
    ],
    "Definition": "đọc"
  },
  {
    "CommonRegularVerbID": 209,
    "OriginalV1": [
      "reawake"
    ],
    "PastV2": [
      "reawoke"
    ],
    "PastParticipleV3": [
      "reawake"
    ],
    "Definition": "đánh thức 1 lần nữa"
  },
  {
    "CommonRegularVerbID": 210,
    "OriginalV1": [
      "rebid"
    ],
    "PastV2": [
      "rebid"
    ],
    "PastParticipleV3": [
      "rebid"
    ],
    "Definition": "trả giá, bỏ thầu"
  },
  {
    "CommonRegularVerbID": 211,
    "OriginalV1": [
      "rebind"
    ],
    "PastV2": [
      "rebound"
    ],
    "PastParticipleV3": [
      "rebound"
    ],
    "Definition": "buộc lại, đóng lại"
  },
  {
    "CommonRegularVerbID": 212,
    "OriginalV1": [
      "rebroadcast"
    ],
    "PastV2": [
      "rebroadcast",
      "rebroadcasted"
    ],
    "PastParticipleV3": [
      "rebroadcast",
      "rebroadcasted"
    ],
    "Definition": "cự tuyệt, khước từ"
  },
  {
    "CommonRegularVerbID": 213,
    "OriginalV1": [
      "rebuild"
    ],
    "PastV2": [
      "rebuilt"
    ],
    "PastParticipleV3": [
      "rebuilt"
    ],
    "Definition": "xây dựng lại"
  },
  {
    "CommonRegularVerbID": 214,
    "OriginalV1": [
      "recast"
    ],
    "PastV2": [
      "recast"
    ],
    "PastParticipleV3": [
      "recast"
    ],
    "Definition": "đúc lại"
  },
  {
    "CommonRegularVerbID": 215,
    "OriginalV1": [
      "recut"
    ],
    "PastV2": [
      "recut"
    ],
    "PastParticipleV3": [
      "recut"
    ],
    "Definition": "cắt lại, băm)"
  },
  {
    "CommonRegularVerbID": 216,
    "OriginalV1": [
      "redeal"
    ],
    "PastV2": [
      "redealt"
    ],
    "PastParticipleV3": [
      "redealt"
    ],
    "Definition": "phát bài lại"
  },
  {
    "CommonRegularVerbID": 217,
    "OriginalV1": [
      "redo"
    ],
    "PastV2": [
      "redid"
    ],
    "PastParticipleV3": [
      "redone"
    ],
    "Definition": "làm lại"
  },
  {
    "CommonRegularVerbID": 218,
    "OriginalV1": [
      "redraw"
    ],
    "PastV2": [
      "redrew"
    ],
    "PastParticipleV3": [
      "redrawn"
    ],
    "Definition": "kéo ngược lại"
  },
  {
    "CommonRegularVerbID": 219,
    "OriginalV1": [
      "refit"
    ],
    "PastV2": [
      "refitted",
      "refit"
    ],
    "PastParticipleV3": [
      "refitted",
      "refit"
    ],
    "Definition": "luồn, xỏ"
  },
  {
    "CommonRegularVerbID": 220,
    "OriginalV1": [
      "regrind"
    ],
    "PastV2": [
      "reground"
    ],
    "PastParticipleV3": [
      "reground"
    ],
    "Definition": "mài sắc lại"
  },
  {
    "CommonRegularVerbID": 221,
    "OriginalV1": [
      "regrow"
    ],
    "PastV2": [
      "regrew"
    ],
    "PastParticipleV3": [
      "regrown"
    ],
    "Definition": "trồng lại"
  },
  {
    "CommonRegularVerbID": 222,
    "OriginalV1": [
      "rehang"
    ],
    "PastV2": [
      "rehung"
    ],
    "PastParticipleV3": [
      "rehung"
    ],
    "Definition": "treo lại"
  },
  {
    "CommonRegularVerbID": 223,
    "OriginalV1": [
      "rehear"
    ],
    "PastV2": [
      "reheard"
    ],
    "PastParticipleV3": [
      "reheard"
    ],
    "Definition": "nghe trình bày lại"
  },
  {
    "CommonRegularVerbID": 224,
    "OriginalV1": [
      "reknit"
    ],
    "PastV2": [
      "reknitted",
      "reknit"
    ],
    "PastParticipleV3": [
      "reknitted",
      "reknit"
    ],
    "Definition": "dệt lại"
  },
  {
    "CommonRegularVerbID": 225,
    "OriginalV1": [
      "relay"
    ],
    "PastV2": [
      "relaid"
    ],
    "PastParticipleV3": [
      "relaid"
    ],
    "Definition": "relaid"
  },
  {
    "CommonRegularVerbID": 226,
    "OriginalV1": [
      "relay"
    ],
    "PastV2": [
      "relayed"
    ],
    "PastParticipleV3": [
      "relayed"
    ],
    "Definition": "truyền âm lại"
  },
  {
    "CommonRegularVerbID": 227,
    "OriginalV1": [
      "relearn"
    ],
    "PastV2": [
      "relearned",
      "relearnt"
    ],
    "PastParticipleV3": [
      "relearned",
      "relearnt"
    ],
    "Definition": "học lại"
  },
  {
    "CommonRegularVerbID": 228,
    "OriginalV1": [
      "relight"
    ],
    "PastV2": [
      "relit",
      "relighted"
    ],
    "PastParticipleV3": [
      "relit",
      "relighted"
    ],
    "Definition": "thắp sáng lại"
  },
  {
    "CommonRegularVerbID": 229,
    "OriginalV1": [
      "remake"
    ],
    "PastV2": [
      "remade"
    ],
    "PastParticipleV3": [
      "remade"
    ],
    "Definition": "làm lại, chế tạo lại"
  },
  {
    "CommonRegularVerbID": 230,
    "OriginalV1": [
      "rend"
    ],
    "PastV2": [
      "rent"
    ],
    "PastParticipleV3": [
      "rent"
    ],
    "Definition": "toạc ra, xé"
  },
  {
    "CommonRegularVerbID": 231,
    "OriginalV1": [
      "repay"
    ],
    "PastV2": [
      "repaid"
    ],
    "PastParticipleV3": [
      "repaid"
    ],
    "Definition": "hoàn tiền lại"
  },
  {
    "CommonRegularVerbID": 232,
    "OriginalV1": [
      "reread"
    ],
    "PastV2": [
      "reread"
    ],
    "PastParticipleV3": [
      "reread"
    ],
    "Definition": "đọc lại"
  },
  {
    "CommonRegularVerbID": 233,
    "OriginalV1": [
      "rerun"
    ],
    "PastV2": [
      "reran"
    ],
    "PastParticipleV3": [
      "rerun"
    ],
    "Definition": "chiếu lại, phát lại"
  },
  {
    "CommonRegularVerbID": 234,
    "OriginalV1": [
      "resell"
    ],
    "PastV2": [
      "resold"
    ],
    "PastParticipleV3": [
      "resold"
    ],
    "Definition": "bán lại"
  },
  {
    "CommonRegularVerbID": 235,
    "OriginalV1": [
      "resend"
    ],
    "PastV2": [
      "resent"
    ],
    "PastParticipleV3": [
      "resent"
    ],
    "Definition": "gửi lại"
  },
  {
    "CommonRegularVerbID": 236,
    "OriginalV1": [
      "reset"
    ],
    "PastV2": [
      "reset"
    ],
    "PastParticipleV3": [
      "reset"
    ],
    "Definition": "đặt lại, lắp lại"
  },
  {
    "CommonRegularVerbID": 237,
    "OriginalV1": [
      "resew"
    ],
    "PastV2": [
      "resewed"
    ],
    "PastParticipleV3": [
      "resewn",
      "resewed"
    ],
    "Definition": "may/khâu lại"
  },
  {
    "CommonRegularVerbID": 238,
    "OriginalV1": [
      "retake"
    ],
    "PastV2": [
      "retook"
    ],
    "PastParticipleV3": [
      "retaken"
    ],
    "Definition": "chiếm lại, tái chiếm"
  },
  {
    "CommonRegularVerbID": 239,
    "OriginalV1": [
      "reteach"
    ],
    "PastV2": [
      "retaught"
    ],
    "PastParticipleV3": [
      "retaught"
    ],
    "Definition": "dạy lại"
  },
  {
    "CommonRegularVerbID": 240,
    "OriginalV1": [
      "retear"
    ],
    "PastV2": [
      "retore"
    ],
    "PastParticipleV3": [
      "retorn"
    ],
    "Definition": "khóc lại"
  },
  {
    "CommonRegularVerbID": 241,
    "OriginalV1": [
      "retell"
    ],
    "PastV2": [
      "retold"
    ],
    "PastParticipleV3": [
      "retold"
    ],
    "Definition": "kể lại"
  },
  {
    "CommonRegularVerbID": 242,
    "OriginalV1": [
      "rethink"
    ],
    "PastV2": [
      "rethought"
    ],
    "PastParticipleV3": [
      "rethought"
    ],
    "Definition": "suy tính lại"
  },
  {
    "CommonRegularVerbID": 243,
    "OriginalV1": [
      "retread"
    ],
    "PastV2": [
      "retread"
    ],
    "PastParticipleV3": [
      "retread"
    ],
    "Definition": "lại giẫm/đạp lên"
  },
  {
    "CommonRegularVerbID": 244,
    "OriginalV1": [
      "retrofit"
    ],
    "PastV2": [
      "retrofitted",
      "retrofit"
    ],
    "PastParticipleV3": [
      "retrofitted",
      "retrofit"
    ],
    "Definition": "trang bị thêm những bộ phận mới"
  },
  {
    "CommonRegularVerbID": 245,
    "OriginalV1": [
      "rewake"
    ],
    "PastV2": [
      "rewoke",
      "rewaked"
    ],
    "PastParticipleV3": [
      "rewaken",
      "rewaked"
    ],
    "Definition": "đánh thức lại"
  },
  {
    "CommonRegularVerbID": 246,
    "OriginalV1": [
      "rewear"
    ],
    "PastV2": [
      "rewore"
    ],
    "PastParticipleV3": [
      "reworn"
    ],
    "Definition": "mặc lại"
  },
  {
    "CommonRegularVerbID": 247,
    "OriginalV1": [
      "reweave"
    ],
    "PastV2": [
      "rewove",
      "reweaved"
    ],
    "PastParticipleV3": [
      "rewove",
      "reweaved"
    ],
    "Definition": "dệt lại"
  },
  {
    "CommonRegularVerbID": 248,
    "OriginalV1": [
      "rewed"
    ],
    "PastV2": [
      "rewed",
      "rewedded"
    ],
    "PastParticipleV3": [
      "rewed",
      "rewedded"
    ],
    "Definition": "kết hôn lại"
  },
  {
    "CommonRegularVerbID": 249,
    "OriginalV1": [
      "rewet"
    ],
    "PastV2": [
      "rewet",
      "rewetted"
    ],
    "PastParticipleV3": [
      "rewet",
      "rewetted"
    ],
    "Definition": "làm ướt lại"
  },
  {
    "CommonRegularVerbID": 250,
    "OriginalV1": [
      "rewin"
    ],
    "PastV2": [
      "rewon"
    ],
    "PastParticipleV3": [
      "rewon"
    ],
    "Definition": "thắng lại"
  },
  {
    "CommonRegularVerbID": 251,
    "OriginalV1": [
      "rewind"
    ],
    "PastV2": [
      "rewound"
    ],
    "PastParticipleV3": [
      "rewound"
    ],
    "Definition": "cuốn lại, lên dây lại"
  },
  {
    "CommonRegularVerbID": 252,
    "OriginalV1": [
      "rewrite"
    ],
    "PastV2": [
      "rewrote"
    ],
    "PastParticipleV3": [
      "rewritten"
    ],
    "Definition": "viết lại"
  },
  {
    "CommonRegularVerbID": 253,
    "OriginalV1": [
      "rid"
    ],
    "PastV2": [
      "rid"
    ],
    "PastParticipleV3": [
      "rid"
    ],
    "Definition": "giải thoát"
  },
  {
    "CommonRegularVerbID": 254,
    "OriginalV1": [
      "ride"
    ],
    "PastV2": [
      "rode"
    ],
    "PastParticipleV3": [
      "ridden"
    ],
    "Definition": "cưỡi"
  },
  {
    "CommonRegularVerbID": 255,
    "OriginalV1": [
      "ring"
    ],
    "PastV2": [
      "rang"
    ],
    "PastParticipleV3": [
      "rung"
    ],
    "Definition": "rung chuông"
  },
  {
    "CommonRegularVerbID": 256,
    "OriginalV1": [
      "rise"
    ],
    "PastV2": [
      "rose"
    ],
    "PastParticipleV3": [
      "risen"
    ],
    "Definition": "đứng dậy, mọc"
  },
  {
    "CommonRegularVerbID": 257,
    "OriginalV1": [
      "roughcast"
    ],
    "PastV2": [
      "roughcast"
    ],
    "PastParticipleV3": [
      "roughcast"
    ],
    "Definition": "tạo hình phỏng chừng"
  },
  {
    "CommonRegularVerbID": 258,
    "OriginalV1": [
      "run"
    ],
    "PastV2": [
      "ran"
    ],
    "PastParticipleV3": [
      "run"
    ],
    "Definition": "chạy"
  },
  {
    "CommonRegularVerbID": 259,
    "OriginalV1": [
      "sand-cast"
    ],
    "PastV2": [
      "sand-cast"
    ],
    "PastParticipleV3": [
      "sand-cast"
    ],
    "Definition": "đúc bằng khuôn cát"
  },
  {
    "CommonRegularVerbID": 260,
    "OriginalV1": [
      "saw"
    ],
    "PastV2": [
      "sawed"
    ],
    "PastParticipleV3": [
      "sawn"
    ],
    "Definition": "cưa"
  },
  {
    "CommonRegularVerbID": 261,
    "OriginalV1": [
      "say"
    ],
    "PastV2": [
      "said"
    ],
    "PastParticipleV3": [
      "said"
    ],
    "Definition": "nói"
  },
  {
    "CommonRegularVerbID": 262,
    "OriginalV1": [
      "see"
    ],
    "PastV2": [
      "saw"
    ],
    "PastParticipleV3": [
      "seen"
    ],
    "Definition": "nhìn thấy"
  },
  {
    "CommonRegularVerbID": 263,
    "OriginalV1": [
      "seek"
    ],
    "PastV2": [
      "sought"
    ],
    "PastParticipleV3": [
      "sought"
    ],
    "Definition": "tìm kiếm"
  },
  {
    "CommonRegularVerbID": 264,
    "OriginalV1": [
      "sell"
    ],
    "PastV2": [
      "sold"
    ],
    "PastParticipleV3": [
      "sold"
    ],
    "Definition": "bán"
  },
  {
    "CommonRegularVerbID": 265,
    "OriginalV1": [
      "send"
    ],
    "PastV2": [
      "sent"
    ],
    "PastParticipleV3": [
      "sent"
    ],
    "Definition": "gửi"
  },
  {
    "CommonRegularVerbID": 266,
    "OriginalV1": [
      "set"
    ],
    "PastV2": [
      "set"
    ],
    "PastParticipleV3": [
      "set"
    ],
    "Definition": "đặt, thiết lập"
  },
  {
    "CommonRegularVerbID": 267,
    "OriginalV1": [
      "sew"
    ],
    "PastV2": [
      "sewed"
    ],
    "PastParticipleV3": [
      "sewn",
      "sewed"
    ],
    "Definition": "may"
  },
  {
    "CommonRegularVerbID": 268,
    "OriginalV1": [
      "shake"
    ],
    "PastV2": [
      "shook"
    ],
    "PastParticipleV3": [
      "shaken"
    ],
    "Definition": "lay, lắc"
  },
  {
    "CommonRegularVerbID": 269,
    "OriginalV1": [
      "shave"
    ],
    "PastV2": [
      "shaved"
    ],
    "PastParticipleV3": [
      "shaved",
      "shaven"
    ],
    "Definition": "cạo (râu, mặt)"
  },
  {
    "CommonRegularVerbID": 270,
    "OriginalV1": [
      "shear"
    ],
    "PastV2": [
      "sheared"
    ],
    "PastParticipleV3": [
      "shorn"
    ],
    "Definition": "xén lông (cừu)"
  },
  {
    "CommonRegularVerbID": 271,
    "OriginalV1": [
      "shed"
    ],
    "PastV2": [
      "shed"
    ],
    "PastParticipleV3": [
      "shed"
    ],
    "Definition": "rơi, rụng"
  },
  {
    "CommonRegularVerbID": 272,
    "OriginalV1": [
      "shine"
    ],
    "PastV2": [
      "shone"
    ],
    "PastParticipleV3": [
      "shone"
    ],
    "Definition": "chiếu sáng"
  },
  {
    "CommonRegularVerbID": 273,
    "OriginalV1": [
      "shit"
    ],
    "PastV2": [
      "shit",
      "shat",
      "shitted"
    ],
    "PastParticipleV3": [
      "shit",
      "shat",
      "shitted"
    ],
    "Definition": "đi đại tiện"
  },
  {
    "CommonRegularVerbID": 274,
    "OriginalV1": [
      "shoot"
    ],
    "PastV2": [
      "shot"
    ],
    "PastParticipleV3": [
      "shot"
    ],
    "Definition": "bắn"
  },
  {
    "CommonRegularVerbID": 275,
    "OriginalV1": [
      "show"
    ],
    "PastV2": [
      "showed"
    ],
    "PastParticipleV3": [
      "shown",
      "showed"
    ],
    "Definition": "cho xem"
  },
  {
    "CommonRegularVerbID": 276,
    "OriginalV1": [
      "shrink"
    ],
    "PastV2": [
      "shrank"
    ],
    "PastParticipleV3": [
      "shrunk"
    ],
    "Definition": "co rút"
  },
  {
    "CommonRegularVerbID": 277,
    "OriginalV1": [
      "shut"
    ],
    "PastV2": [
      "shut"
    ],
    "PastParticipleV3": [
      "shut"
    ],
    "Definition": "đóng lại"
  },
  {
    "CommonRegularVerbID": 278,
    "OriginalV1": [
      "sight-read"
    ],
    "PastV2": [
      "sight-read"
    ],
    "PastParticipleV3": [
      "sight-read"
    ],
    "Definition": "chơi hoặc hát mà không cần nghiên cứu trước"
  },
  {
    "CommonRegularVerbID": 279,
    "OriginalV1": [
      "sing"
    ],
    "PastV2": [
      "sang"
    ],
    "PastParticipleV3": [
      "sung"
    ],
    "Definition": "ca hát"
  },
  {
    "CommonRegularVerbID": 280,
    "OriginalV1": [
      "sink"
    ],
    "PastV2": [
      "sank"
    ],
    "PastParticipleV3": [
      "sunk"
    ],
    "Definition": "chìm, lặn"
  },
  {
    "CommonRegularVerbID": 281,
    "OriginalV1": [
      "sit"
    ],
    "PastV2": [
      "sat"
    ],
    "PastParticipleV3": [
      "sat"
    ],
    "Definition": "ngồi"
  },
  {
    "CommonRegularVerbID": 282,
    "OriginalV1": [
      "slay"
    ],
    "PastV2": [
      "slew"
    ],
    "PastParticipleV3": [
      "slain"
    ],
    "Definition": "sát hại, giết hại"
  },
  {
    "CommonRegularVerbID": 283,
    "OriginalV1": [
      "sleep"
    ],
    "PastV2": [
      "slept"
    ],
    "PastParticipleV3": [
      "slept"
    ],
    "Definition": "ngủ"
  },
  {
    "CommonRegularVerbID": 284,
    "OriginalV1": [
      "slide"
    ],
    "PastV2": [
      "slid"
    ],
    "PastParticipleV3": [
      "slid"
    ],
    "Definition": "trượt, lướt"
  },
  {
    "CommonRegularVerbID": 285,
    "OriginalV1": [
      "sling"
    ],
    "PastV2": [
      "slung"
    ],
    "PastParticipleV3": [
      "slung"
    ],
    "Definition": "ném mạnh"
  },
  {
    "CommonRegularVerbID": 286,
    "OriginalV1": [
      "slink"
    ],
    "PastV2": [
      "slunk"
    ],
    "PastParticipleV3": [
      "slunk"
    ],
    "Definition": "lẻn đi"
  },
  {
    "CommonRegularVerbID": 287,
    "OriginalV1": [
      "slit"
    ],
    "PastV2": [
      "slit"
    ],
    "PastParticipleV3": [
      "slit"
    ],
    "Definition": "rạch, khứa"
  },
  {
    "CommonRegularVerbID": 288,
    "OriginalV1": [
      "smell"
    ],
    "PastV2": [
      "smelt"
    ],
    "PastParticipleV3": [
      "smelt"
    ],
    "Definition": "ngửi"
  },
  {
    "CommonRegularVerbID": 289,
    "OriginalV1": [
      "smite"
    ],
    "PastV2": [
      "smote"
    ],
    "PastParticipleV3": [
      "smitten"
    ],
    "Definition": "đập mạnh"
  },
  {
    "CommonRegularVerbID": 290,
    "OriginalV1": [
      "sow"
    ],
    "PastV2": [
      "sowed"
    ],
    "PastParticipleV3": [
      "sownsewed"
    ],
    "Definition": "gieo; rải"
  },
  {
    "CommonRegularVerbID": 291,
    "OriginalV1": [
      "sneak"
    ],
    "PastV2": [
      "sneaked",
      "snuck"
    ],
    "PastParticipleV3": [
      "sneaked",
      "snuck"
    ],
    "Definition": "trốn, lén"
  },
  {
    "CommonRegularVerbID": 292,
    "OriginalV1": [
      "speak"
    ],
    "PastV2": [
      "spoke"
    ],
    "PastParticipleV3": [
      "spoken"
    ],
    "Definition": "nói"
  },
  {
    "CommonRegularVerbID": 293,
    "OriginalV1": [
      "speed"
    ],
    "PastV2": [
      "sped",
      "speeded"
    ],
    "PastParticipleV3": [
      "sped",
      "speeded"
    ],
    "Definition": "chạy vụt"
  },
  {
    "CommonRegularVerbID": 294,
    "OriginalV1": [
      "spell"
    ],
    "PastV2": [
      "spelt",
      "spelled"
    ],
    "PastParticipleV3": [
      "spelt",
      "spelled"
    ],
    "Definition": "đánh vần"
  },
  {
    "CommonRegularVerbID": 295,
    "OriginalV1": [
      "spend"
    ],
    "PastV2": [
      "spent"
    ],
    "PastParticipleV3": [
      "spent"
    ],
    "Definition": "tiêu xài"
  },
  {
    "CommonRegularVerbID": 296,
    "OriginalV1": [
      "spill"
    ],
    "PastV2": [
      "spilt",
      "spilled"
    ],
    "PastParticipleV3": [
      "spilt",
      "spilled"
    ],
    "Definition": "tràn, đổ ra"
  },
  {
    "CommonRegularVerbID": 297,
    "OriginalV1": [
      "spin"
    ],
    "PastV2": [
      "spunspan"
    ],
    "PastParticipleV3": [
      "spun"
    ],
    "Definition": "quay sợi"
  },
  {
    "CommonRegularVerbID": 298,
    "OriginalV1": [
      "spoil"
    ],
    "PastV2": [
      "spoilt",
      "spoiled"
    ],
    "PastParticipleV3": [
      "spoilt",
      "spoiled"
    ],
    "Definition": "làm hỏng"
  },
  {
    "CommonRegularVerbID": 299,
    "OriginalV1": [
      "spread"
    ],
    "PastV2": [
      "spread"
    ],
    "PastParticipleV3": [
      "spread"
    ],
    "Definition": "lan truyền"
  },
  {
    "CommonRegularVerbID": 300,
    "OriginalV1": [
      "stand"
    ],
    "PastV2": [
      "stood"
    ],
    "PastParticipleV3": [
      "stood"
    ],
    "Definition": "đứng"
  },
  {
    "CommonRegularVerbID": 301,
    "OriginalV1": [
      "steal"
    ],
    "PastV2": [
      "stole"
    ],
    "PastParticipleV3": [
      "stolen"
    ],
    "Definition": "đánh cắp"
  },
  {
    "CommonRegularVerbID": 302,
    "OriginalV1": [
      "stick"
    ],
    "PastV2": [
      "stuck"
    ],
    "PastParticipleV3": [
      "stuck"
    ],
    "Definition": "ghim vào, đính"
  },
  {
    "CommonRegularVerbID": 303,
    "OriginalV1": [
      "sting"
    ],
    "PastV2": [
      "stung"
    ],
    "PastParticipleV3": [
      "stung"
    ],
    "Definition": "châm, chích, đốt"
  },
  {
    "CommonRegularVerbID": 304,
    "OriginalV1": [
      "stink"
    ],
    "PastV2": [
      "stunk",
      "stank"
    ],
    "PastParticipleV3": [
      "stunk"
    ],
    "Definition": "bốc mùi hôi"
  },
  {
    "CommonRegularVerbID": 305,
    "OriginalV1": [
      "stride"
    ],
    "PastV2": [
      "strode"
    ],
    "PastParticipleV3": [
      "stridden"
    ],
    "Definition": "bước sải"
  },
  {
    "CommonRegularVerbID": 306,
    "OriginalV1": [
      "strike"
    ],
    "PastV2": [
      "struck"
    ],
    "PastParticipleV3": [
      "struck"
    ],
    "Definition": "đánh đập"
  },
  {
    "CommonRegularVerbID": 307,
    "OriginalV1": [
      "string"
    ],
    "PastV2": [
      "strung"
    ],
    "PastParticipleV3": [
      "strung"
    ],
    "Definition": "gắn dây vào"
  },
  {
    "CommonRegularVerbID": 308,
    "OriginalV1": [
      "sunburn"
    ],
    "PastV2": [
      "sunburned",
      "sunburnt"
    ],
    "PastParticipleV3": [
      "sunburned",
      "sunburnt"
    ],
    "Definition": "cháy nắng"
  },
  {
    "CommonRegularVerbID": 309,
    "OriginalV1": [
      "swear"
    ],
    "PastV2": [
      "swore"
    ],
    "PastParticipleV3": [
      "sworn"
    ],
    "Definition": "tuyên thệ"
  },
  {
    "CommonRegularVerbID": 310,
    "OriginalV1": [
      "sweat"
    ],
    "PastV2": [
      "sweat",
      "sweated"
    ],
    "PastParticipleV3": [
      "sweat",
      "sweated"
    ],
    "Definition": "đổ mồ hôi"
  },
  {
    "CommonRegularVerbID": 311,
    "OriginalV1": [
      "sweep"
    ],
    "PastV2": [
      "swept"
    ],
    "PastParticipleV3": [
      "swept"
    ],
    "Definition": "quét"
  },
  {
    "CommonRegularVerbID": 312,
    "OriginalV1": [
      "swell"
    ],
    "PastV2": [
      "swelled"
    ],
    "PastParticipleV3": [
      "swollen",
      "swelled"
    ],
    "Definition": "phồng, sưng"
  },
  {
    "CommonRegularVerbID": 313,
    "OriginalV1": [
      "swim"
    ],
    "PastV2": [
      "swam"
    ],
    "PastParticipleV3": [
      "swum"
    ],
    "Definition": "bơi lội"
  },
  {
    "CommonRegularVerbID": 314,
    "OriginalV1": [
      "swing"
    ],
    "PastV2": [
      "swung"
    ],
    "PastParticipleV3": [
      "swung"
    ],
    "Definition": "đong đưa"
  },
  {
    "CommonRegularVerbID": 315,
    "OriginalV1": [
      "take"
    ],
    "PastV2": [
      "took"
    ],
    "PastParticipleV3": [
      "taken"
    ],
    "Definition": "cầm, lấy"
  },
  {
    "CommonRegularVerbID": 316,
    "OriginalV1": [
      "teach"
    ],
    "PastV2": [
      "taught"
    ],
    "PastParticipleV3": [
      "taught"
    ],
    "Definition": "dạy, giảng dạy"
  },
  {
    "CommonRegularVerbID": 317,
    "OriginalV1": [
      "tear"
    ],
    "PastV2": [
      "tore"
    ],
    "PastParticipleV3": [
      "torn"
    ],
    "Definition": "xé, rách"
  },
  {
    "CommonRegularVerbID": 318,
    "OriginalV1": [
      "telecast"
    ],
    "PastV2": [
      "telecast"
    ],
    "PastParticipleV3": [
      "telecast"
    ],
    "Definition": "phát đi bằng truyền hình"
  },
  {
    "CommonRegularVerbID": 319,
    "OriginalV1": [
      "tell"
    ],
    "PastV2": [
      "told"
    ],
    "PastParticipleV3": [
      "told"
    ],
    "Definition": "kể, bảo"
  },
  {
    "CommonRegularVerbID": 320,
    "OriginalV1": [
      "think"
    ],
    "PastV2": [
      "thought"
    ],
    "PastParticipleV3": [
      "thought"
    ],
    "Definition": "suy nghĩ"
  },
  {
    "CommonRegularVerbID": 321,
    "OriginalV1": [
      "throw"
    ],
    "PastV2": [
      "threw"
    ],
    "PastParticipleV3": [
      "thrown"
    ],
    "Definition": "ném, liệng"
  },
  {
    "CommonRegularVerbID": 322,
    "OriginalV1": [
      "thrust"
    ],
    "PastV2": [
      "thrust"
    ],
    "PastParticipleV3": [
      "thrust"
    ],
    "Definition": "thọc, nhấn"
  },
  {
    "CommonRegularVerbID": 323,
    "OriginalV1": [
      "tread"
    ],
    "PastV2": [
      "trod"
    ],
    "PastParticipleV3": [
      "trodden",
      "trod"
    ],
    "Definition": "giẫm, đạp"
  },
  {
    "CommonRegularVerbID": 324,
    "OriginalV1": [
      "typewrite"
    ],
    "PastV2": [
      "typewrote"
    ],
    "PastParticipleV3": [
      "typewritten"
    ],
    "Definition": "đánh máy"
  },
  {
    "CommonRegularVerbID": 325,
    "OriginalV1": [
      "unbend"
    ],
    "PastV2": [
      "unbent"
    ],
    "PastParticipleV3": [
      "unbent"
    ],
    "Definition": "làm thẳng lại"
  },
  {
    "CommonRegularVerbID": 326,
    "OriginalV1": [
      "unbind"
    ],
    "PastV2": [
      "unbound"
    ],
    "PastParticipleV3": [
      "unbound"
    ],
    "Definition": "mở, tháo ra"
  },
  {
    "CommonRegularVerbID": 327,
    "OriginalV1": [
      "unclothe"
    ],
    "PastV2": [
      "unclothed",
      "unclad"
    ],
    "PastParticipleV3": [
      "unclothed",
      "unclad"
    ],
    "Definition": "cởi áo, lột trần"
  },
  {
    "CommonRegularVerbID": 328,
    "OriginalV1": [
      "undercut"
    ],
    "PastV2": [
      "undercut"
    ],
    "PastParticipleV3": [
      "undercut"
    ],
    "Definition": "ra giá rẻ hơn"
  },
  {
    "CommonRegularVerbID": 329,
    "OriginalV1": [
      "underfeed"
    ],
    "PastV2": [
      "underfed"
    ],
    "PastParticipleV3": [
      "underfed"
    ],
    "Definition": "cho ăn đói, thiếu ăn"
  },
  {
    "CommonRegularVerbID": 330,
    "OriginalV1": [
      "undergo"
    ],
    "PastV2": [
      "underwent"
    ],
    "PastParticipleV3": [
      "undergone"
    ],
    "Definition": "trải qua"
  },
  {
    "CommonRegularVerbID": 331,
    "OriginalV1": [
      "underlie"
    ],
    "PastV2": [
      "underlay"
    ],
    "PastParticipleV3": [
      "underlain"
    ],
    "Definition": "nằm dưới"
  },
  {
    "CommonRegularVerbID": 332,
    "OriginalV1": [
      "underpay"
    ],
    "PastV2": [
      "underpaid"
    ],
    "PastParticipleV3": [
      "underpaid"
    ],
    "Definition": "trả lương thấp"
  },
  {
    "CommonRegularVerbID": 333,
    "OriginalV1": [
      "undersell"
    ],
    "PastV2": [
      "undersold"
    ],
    "PastParticipleV3": [
      "undersold"
    ],
    "Definition": "bán rẻ hơn"
  },
  {
    "CommonRegularVerbID": 334,
    "OriginalV1": [
      "understand"
    ],
    "PastV2": [
      "understand"
    ],
    "PastParticipleV3": [
      "understand"
    ],
    "Definition": "hiểu"
  },
  {
    "CommonRegularVerbID": 335,
    "OriginalV1": [
      "undertake"
    ],
    "PastV2": [
      "undertook"
    ],
    "PastParticipleV3": [
      "undertook"
    ],
    "Definition": "đảm nhận"
  },
  {
    "CommonRegularVerbID": 336,
    "OriginalV1": [
      "underwrite"
    ],
    "PastV2": [
      "underwrote"
    ],
    "PastParticipleV3": [
      "underwritten"
    ],
    "Definition": "bảo hiểm"
  },
  {
    "CommonRegularVerbID": 337,
    "OriginalV1": [
      "undo"
    ],
    "PastV2": [
      "undid"
    ],
    "PastParticipleV3": [
      "undid"
    ],
    "Definition": "tháo ra"
  },
  {
    "CommonRegularVerbID": 338,
    "OriginalV1": [
      "unfreeze"
    ],
    "PastV2": [
      "unfroze"
    ],
    "PastParticipleV3": [
      "unfrozen"
    ],
    "Definition": "làm tan đông"
  },
  {
    "CommonRegularVerbID": 339,
    "OriginalV1": [
      "unhang"
    ],
    "PastV2": [
      "unhung"
    ],
    "PastParticipleV3": [
      "unhung"
    ],
    "Definition": "hạ xuống, bỏ xuống"
  },
  {
    "CommonRegularVerbID": 340,
    "OriginalV1": [
      "unhide"
    ],
    "PastV2": [
      "unhid"
    ],
    "PastParticipleV3": [
      "unhidden"
    ],
    "Definition": "hiển thị, không ẩn"
  },
  {
    "CommonRegularVerbID": 341,
    "OriginalV1": [
      "unlearn"
    ],
    "PastV2": [
      "unlearned",
      "unlearnt"
    ],
    "PastParticipleV3": [
      "unlearned",
      "unlearnt"
    ],
    "Definition": "gạt bỏ, quên"
  },
  {
    "CommonRegularVerbID": 342,
    "OriginalV1": [
      "unspin"
    ],
    "PastV2": [
      "unspun"
    ],
    "PastParticipleV3": [
      "unspun"
    ],
    "Definition": "quay ngược"
  },
  {
    "CommonRegularVerbID": 343,
    "OriginalV1": [
      "unwind"
    ],
    "PastV2": [
      "unwound"
    ],
    "PastParticipleV3": [
      "unwound"
    ],
    "Definition": "tháo ra"
  },
  {
    "CommonRegularVerbID": 344,
    "OriginalV1": [
      "uphold"
    ],
    "PastV2": [
      "upheld"
    ],
    "PastParticipleV3": [
      "upheld"
    ],
    "Definition": "ủng hộ"
  },
  {
    "CommonRegularVerbID": 345,
    "OriginalV1": [
      "upset"
    ],
    "PastV2": [
      "upset"
    ],
    "PastParticipleV3": [
      "upset"
    ],
    "Definition": "đánh đổ, lật đổ"
  },
  {
    "CommonRegularVerbID": 346,
    "OriginalV1": [
      "wake"
    ],
    "PastV2": [
      "woke",
      "wake"
    ],
    "PastParticipleV3": [
      "woken",
      "waked"
    ],
    "Definition": "thức giấc"
  },
  {
    "CommonRegularVerbID": 347,
    "OriginalV1": [
      "waylay"
    ],
    "PastV2": [
      "waylaid"
    ],
    "PastParticipleV3": [
      "waylaid"
    ],
    "Definition": ""
  },
  {
    "CommonRegularVerbID": 348,
    "OriginalV1": [
      "wear"
    ],
    "PastV2": [
      "wore"
    ],
    "PastParticipleV3": [
      "worn"
    ],
    "Definition": "mặc"
  },
  {
    "CommonRegularVerbID": 349,
    "OriginalV1": [
      "weave"
    ],
    "PastV2": [
      "wove",
      "weaved"
    ],
    "PastParticipleV3": [
      "woven",
      "weaved"
    ],
    "Definition": "dệt"
  },
  {
    "CommonRegularVerbID": 350,
    "OriginalV1": [
      "wed"
    ],
    "PastV2": [
      "wed",
      "wedded"
    ],
    "PastParticipleV3": [
      "wed",
      "wedded"
    ],
    "Definition": "kết hôn"
  },
  {
    "CommonRegularVerbID": 351,
    "OriginalV1": [
      "weep"
    ],
    "PastV2": [
      "wept"
    ],
    "PastParticipleV3": [
      "wept"
    ],
    "Definition": "khóc"
  },
  {
    "CommonRegularVerbID": 352,
    "OriginalV1": [
      "wet"
    ],
    "PastV2": [
      "wet",
      "wetted"
    ],
    "PastParticipleV3": [
      "wet",
      "wetted"
    ],
    "Definition": "làm ướt"
  },
  {
    "CommonRegularVerbID": 353,
    "OriginalV1": [
      "win"
    ],
    "PastV2": [
      "won"
    ],
    "PastParticipleV3": [
      "won"
    ],
    "Definition": "thắng, chiến thắng"
  },
  {
    "CommonRegularVerbID": 354,
    "OriginalV1": [
      "wind"
    ],
    "PastV2": [
      "wound"
    ],
    "PastParticipleV3": [
      "wound"
    ],
    "Definition": "quấn"
  },
  {
    "CommonRegularVerbID": 355,
    "OriginalV1": [
      "withdraw"
    ],
    "PastV2": [
      "withdrew"
    ],
    "PastParticipleV3": [
      "withdrawn"
    ],
    "Definition": "rút lui"
  },
  {
    "CommonRegularVerbID": 356,
    "OriginalV1": [
      "withhold"
    ],
    "PastV2": [
      "withheld"
    ],
    "PastParticipleV3": [
      "withheld"
    ],
    "Definition": "từ khước"
  },
  {
    "CommonRegularVerbID": 357,
    "OriginalV1": [
      "withstand"
    ],
    "PastV2": [
      "withstood"
    ],
    "PastParticipleV3": [
      "withstood"
    ],
    "Definition": "cầm cự"
  },
  {
    "CommonRegularVerbID": 358,
    "OriginalV1": [
      "work"
    ],
    "PastV2": [
      "worked"
    ],
    "PastParticipleV3": [
      "worked"
    ],
    "Definition": "rèn, nhào nặn đất"
  },
  {
    "CommonRegularVerbID": 359,
    "OriginalV1": [
      "wring"
    ],
    "PastV2": [
      "wrung"
    ],
    "PastParticipleV3": [
      "wrung"
    ],
    "Definition": "vặn, siết chặt"
  },
  {
    "CommonRegularVerbID": 360,
    "OriginalV1": [
      "write"
    ],
    "PastV2": [
      "wrote"
    ],
    "PastParticipleV3": [
      "written"
    ],
    "Definition": "viết"
  }
];