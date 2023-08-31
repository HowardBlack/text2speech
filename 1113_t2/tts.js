/*
    Reference:
        1. https://mdn.github.io/dom-examples/web-speech-api/speak-easy-synthesis/

*/
// 取得內建 Web Speech API
const synth = window.speechSynthesis;
// 建立 語音列表 為空
let voices = [];
// 找到 html page select 元素
const voiceSelect = document.querySelector("select");

// 建立語音清單方法
function populateVoiceList() {
    // option 選項根據文字順序排序
    voices = synth.getVoices().sort(function (a, b) {
        const aname = a.name.toUpperCase();
        const bname = b.name.toUpperCase();

        if (aname < bname) {
            return -1;
        } else if (aname == bname) {
            return 0;
        } else {
            return +1;
        }
    });
    console.log(voices);
    // 預設選取的 options
    const selectedIndex =
        voiceSelect.selectedIndex < 0 ? 14 : voiceSelect.selectedIndex;
    // 建立 option 元素
    for (let i = 0; i < voices.length; i++) {
        const option = document.createElement("option");
        option.textContent = `${voices[i].name} (${voices[i].lang})`;

        if (voices[i].default) {
            option.textContent += " -- DEFAULT";
        }

        option.setAttribute("data-lang", voices[i].lang);
        option.setAttribute("data-name", voices[i].name);
        voiceSelect.appendChild(option);
    }
    // 設定預設項目
    voiceSelect.selectedIndex = selectedIndex;
}
// 執行建立語音清單方法
populateVoiceList();

if (speechSynthesis.onvoiceschanged !== undefined) {
    speechSynthesis.onvoiceschanged = populateVoiceList;
}

// 說出語音
function Speak(content) {
    // 正在執行語音，誤觸防呆，以下不在執行，避免複述
    if (synth.speaking) {
        console.error("speechSynthesis.speaking");
        return;
    }

    // 判斷內容不為空時
    if (content !== "") {
        // 建立 SpeechSynthesisUtterance 物件
        const utterThis = new SpeechSynthesisUtterance(content);

        // 結束時
        utterThis.onend = function (event) {
            console.log("SpeechSynthesisUtterance.onend");
        };

        // 錯誤發生時
        utterThis.onerror = function (event) {
            console.error("SpeechSynthesisUtterance.onerror");
        };

        // 取得選取的 option data-name 屬性值
        const selectedOption =
            voiceSelect.selectedOptions[0].getAttribute("data-name");
        
        // 遍訪 voices 陣列檢查符合項目，再將符合項目放置 voice 中
        for (let i = 0; i < voices.length; i++) {
            if (voices[i].name === selectedOption) {
                utterThis.voice = voices[i];
                break;
            }
        }

        // 說話
        synth.speak(utterThis);
    }
}

// 取消語音
function Cancel() {
    synth.cancel();
}

/*
$('#play').click(function () {
    Speak('測試，我是你好');
})

$('#cancel').click(() => Cancel());

*/