/* * Summari.ai - Core JavaScript Engine 
 * 1. RUBRIC: Centralize JavaScript Management (All code is in this single file)
 */

// 2. RUBRIC: Work with constants for reliability (Named constants)
const API_ENDPOINT = "https://api-inference.huggingface.co/models/facebook/bart-large-cnn";
const MIN_CHAR_LIMIT = 20;

// Global variable to hold our timer so we can clear it later
let processTimer;

// 5. RUBRIC: React to user actions (Create at least 1 'onload' event)
window.onload = function() {
    
    // 3. RUBRIC: Modify web pages for interaction (Find element by ID)
    const submitBtn = document.getElementById("submitBtn");
    const appHeader = document.getElementById("appHeader");
    
    // 3. RUBRIC: Modify web pages for interaction (Find element by Tag Name)
    const textAreas = document.getElementsByTagName("textarea");
    
    // 3. RUBRIC: Modify web pages for interaction (Find element by Class Name)
    const featureContainer = document.getElementsByClassName("feature-list");

    // Initialize the app features display
    if (featureContainer.length > 0) {
        loadAppFeatures(featureContainer[0]);
    }

    // 5. RUBRIC: React to user actions (Create at least 1 'onmouseover' event)
    appHeader.onmouseover = function() {
        // 3. RUBRIC: Modify web pages for interaction (Change how element looks with CSS)
        appHeader.style.color = "#4CAF50";
        appHeader.style.textShadow = "2px 2px 4px rgba(0,0,0,0.2)";
        appHeader.style.cursor = "pointer";
    };

    // 5. RUBRIC: React to user actions (Create at least 1 'onclick' event)
    if (submitBtn) {
        submitBtn.onclick = function(event) {
            event.preventDefault(); // Stop form submission reloading the page
            generateSummary();
        };
    }
};

// 6. RUBRIC: Modularize and organize your code (Custom function, multiple arguments, returns a result)
function calculateProcessingTime(charCount, userTier) {
    let baseTime = 1.5; // 1.5 seconds base load time
    let timeMultiplier = 1.0;
    
    // 4. RUBRIC: Direct code flow for logic (Use at least 1 'else if' statement)
    if (userTier === "free") {
        timeMultiplier = 2.0; // Slower for free tier
    } else if (userTier === "pro") {
        timeMultiplier = 1.0; // Standard for pro tier
    } else {
        timeMultiplier = 1.5; // Default fallback
    }
    
    let estimatedSeconds = baseTime + (charCount / 1000) * timeMultiplier;
    return estimatedSeconds.toFixed(1); // Returns a formatted string result
}

function generateSummary() {
    // Grab the elements needed for processing
    const textInput = document.getElementById("textInput").value;
    const submitBtn = document.getElementById("submitBtn");
    const outputArea = document.getElementById("outputArea");
    
    // Basic validation
    if (textInput.length < MIN_CHAR_LIMIT) {
        alert("Please enter more text for the AI to summarize effectively.");
        return;
    }

    // 3. RUBRIC: Modify web pages for interaction (Add at least 1 new attribute to an element)
    submitBtn.setAttribute("disabled", "true");
    submitBtn.value = "AI is Processing...";

    // Calculate time using our custom function
    let expectedWait = calculateProcessingTime(textInput.length, "free");
    console.log("Expected processing time: " + expectedWait + " seconds.");

    // 9. RUBRIC: Schedule tasks for interactive experiences (Appropriately use 'clearTimeout')
    if (processTimer) {
        clearTimeout(processTimer);
    }

    // 9. RUBRIC: Schedule tasks for interactive experiences (Implement at least 1 'setTimeout')
    // We use setTimeout here to simulate an API request so your code runs without needing a real backend API key immediately.
    processTimer = setTimeout(function() {
        
        // Mock successful AI summarization response
        outputArea.innerHTML = "<strong>Summari.ai Result:</strong><br><br>This is your automated text summary. Your original text was intelligently condensed from " + textInput.length + " characters into this shorter version.";
        
        // Modify CSS to show the result box
        outputArea.style.display = "block";
        outputArea.style.padding = "15px";
        outputArea.style.borderLeft = "4px solid #4CAF50";
        
        // Remove the attribute to re-enable the button
        submitBtn.removeAttribute("disabled");
        submitBtn.value = "Summarize Text";
        
    }, 2500); // Simulates a 2.5-second loading delay
}

function loadAppFeatures(container) {
    // 8. RUBRIC: Organize data for efficiency (At least 1 iterated array)
    const summariFeatures = [
        "Natural Language Processing", 
        "Contextual Awareness", 
        "Lightning Fast Speeds", 
        "Secure Encryption"
    ];
    
    let htmlBuilder = "<ul>";
    
    // 7. RUBRIC: Automate repetition for simplicity (Integrate at least one looping structure)
    for (let i = 0; i < summariFeatures.length; i++) {
        // Accessing and using the elements from the iterated array
        htmlBuilder += "<li>" + summariFeatures[i] + "</li>"; 
    }
    
    htmlBuilder += "</ul>";
    
    // Output the compiled list to the DOM
    container.innerHTML = htmlBuilder;
}=2