// Initialize new SpeechSynthesisUtterance object
let speech = new SpeechSynthesisUtterance();

// Set Speech Language
speech.lang = "en";

let voices = []; // global array of available voices

window.speechSynthesis.onvoiceschanged = () => {
    // Get List of Voices
    voices = window.speechSynthesis.getVoices();

    // Initially set the First Voice in the Array.
    speech.voice = voices[0];

    // Set the Voice Select List. (Set the Index as the value, which we'll use later when the user updates the Voice using the Select Menu.)
    let voiceSelect = document.querySelector("#voices");
    voices.forEach(
        (voice, i) => (voiceSelect.options[i] = new Option(voice.name, i))
    );
};

document.querySelector("#play").addEventListener("click", () => {
    // Set the text property with the value of the textarea
    speech.text = document.querySelector("textarea").value;

    // Start Speaking
    window.speechSynthesis.speak(speech);
});

document.querySelector("#cancel").addEventListener("click", () => {
    // Cancel the speechSynthesis instance
    window.speechSynthesis.cancel();
});
