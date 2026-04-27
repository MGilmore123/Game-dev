/* FILENAME: script.js
   PURPOSE: Handles the logic for Summary.Ai (Theme, AI Simulation, Copy, & Speech)
*/

document.addEventListener('DOMContentLoaded', () => {
    
    // --- DOM ELEMENTS ---
    const themeToggle = document.getElementById('themeToggle');
    const themeIcon = themeToggle.querySelector('i');
    const themeText = themeToggle.querySelector('span');
    
    const inputText = document.getElementById('inputText');
    const outputText = document.getElementById('outputText');
    const charCount = document.getElementById('charCount');
    const summarizeBtn = document.getElementById('summarizeBtn');

    // --- 1. THEME TOGGLE LOGIC ---
    let isDarkMode = false;

    themeToggle.addEventListener('click', () => {
        isDarkMode = !isDarkMode;
        if (isDarkMode) {
            document.documentElement.setAttribute('data-theme', 'dark');
            themeIcon.classList.replace('fa-moon', 'fa-sun');
            themeText.textContent = "Day Mode";
        } else {
            document.documentElement.setAttribute('data-theme', 'light');
            themeIcon.classList.replace('fa-sun', 'fa-moon');
            themeText.textContent = "Night Mode";
        }
    });

    // --- 2. CHARACTER COUNTER ---
    inputText.addEventListener('input', () => {
        const length = inputText.value.length;
        charCount.textContent = `${length} chars`;
    });

    // --- 3. CLEAR TEXT FUNCTION ---
    window.clearText = function() {
        inputText.value = '';
        charCount.textContent = '0 chars';
        resetOutput();
    };

    function resetOutput() {
        outputText.innerHTML = '<span style="color: var(--text-secondary); font-style: italic;">Waiting for input...</span>';
    }

    // --- 4. COPY TO CLIPBOARD ---
    window.copyToClipboard = function() {
        const textToCopy = outputText.innerText;
        if(!textToCopy || textToCopy.includes("Waiting for input")) return;

        navigator.clipboard.writeText(textToCopy).then(() => {
            // Show a temporary "Copied!" feedback on the button if you like
            alert("Summary copied to clipboard!"); 
        });
    };

    // --- 5. TEXT-TO-SPEECH (NEW COOL FEATURE) ---
    // Make sure to add a button with onclick="readSummary()" in your HTML to use this!
    window.readSummary = function() {
        const text = outputText.innerText;
        if(!text || text.includes("Waiting for input")) return;

        // Stop any current speaking
        window.speechSynthesis.cancel();

        const utterance = new SpeechSynthesisUtterance(text);
        utterance.rate = 1; // Speed: 1 is normal
        utterance.pitch = 1; // Pitch: 1 is normal
        window.speechSynthesis.speak(utterance);
    };

    // --- 6. SIMULATED AI SUMMARIZATION ---
    summarizeBtn.addEventListener('click', () => {
        const text = inputText.value.trim();
        
        // Basic Validation
        if (!text) {
            alert("Please enter some text to summarize first.");
            return;
        }
        if (text.length < 20) {
            alert("Text is too short. Please enter a longer sentence or paragraph.");
            return;
        }

        // UI Loading State
        summarizeBtn.disabled = true;
        const originalBtnText = summarizeBtn.innerHTML;
        summarizeBtn.innerHTML = `<i class="fas fa-spinner fa-spin"></i> AI is Thinking...`;
        outputText.innerHTML = `<span class="loading-dots">Analyzing text</span>`;

        // Simulate API Delay (2 seconds)
        setTimeout(() => {
            // --- MOCK AI LOGIC ---
            // (Replace this block with a real fetch() call to OpenAI if you upgrade later)
            const sentences = text.split('. ');
            // Simple logic: Take the first half of the sentences
            const summaryLength = Math.max(1, Math.floor(sentences.length / 2));
            const summary = sentences.slice(0, summaryLength).join('. ') + (sentences.length > 1 ? '.' : '');
            
            // Clear loading animation
            outputText.innerHTML = "";
            
            // Run Typewriter Effect
            typeWriterEffect(summary, 0);

            // Reset Button
            summarizeBtn.disabled = false;
            summarizeBtn.innerHTML = originalBtnText;
        }, 2000);
    });

    // --- TYPEWRITER ANIMATION HELPER ---
    function typeWriterEffect(text, i) {
        if (i < text.length) {
            outputText.innerHTML += text.charAt(i);
            setTimeout(() => typeWriterEffect(text, i + 1), 20); // 20ms delay per letter
        }
    }
});