document.addEventListener('DOMContentLoaded', () => {
    const quoteText = document.getElementById('quoteText');
    const quoteAuthor = document.getElementById('quoteAuthor');
    const addQuoteButton = document.getElementById('addQuoteButton');
    const quoteList = document.getElementById('quoteList');

    // Load quotes from Local Storage and display them
    loadQuotes();

    addQuoteButton.addEventListener('click', () => {
        const text = quoteText.value;
        const author = quoteAuthor.value;
        if (text && author) {
            addQuote(text, author);
        }
    });

    // Function to add a quote to Local Storage
    function addQuote(text, author) {
        let quotes = getQuotesFromStorage();
        const id = quotes.length > 0 ? quotes[quotes.length - 1].id + 1 : 1;  // Generate unique ID
        const newQuote = { id, text, author };
        quotes.push(newQuote);
        saveQuotesToStorage(quotes);
        displayQuotes(quotes);
        quoteText.value = '';
        quoteAuthor.value = '';
    }

    // Function to get quotes from Local Storage
    function getQuotesFromStorage() {
        return JSON.parse(localStorage.getItem('quotes')) || [];
    }

    // Function to save quotes to Local Storage
    function saveQuotesToStorage(quotes) {
        localStorage.setItem('quotes', JSON.stringify(quotes));
    }

    // Function to display quotes
    function displayQuotes(quotes) {
        quoteList.innerHTML = '';  // Clear current list
        quotes.forEach(quote => {
            const li = document.createElement('li');
            li.innerHTML = `${quote.text} - <strong>${quote.author}</strong>
                <button onclick="deleteQuote(${quote.id})">Delete</button>
                <button onclick="editQuote(${quote.id})">Edit</button>`;
            quoteList.appendChild(li);
        });
    }

    // Function to load and display quotes on page load
    function loadQuotes() {
        const quotes = getQuotesFromStorage();
        displayQuotes(quotes);
    }

    // Function to delete a quote
    window.deleteQuote = function (id) {
        let quotes = getQuotesFromStorage();
        quotes = quotes.filter(quote => quote.id !== id);
        saveQuotesToStorage(quotes);
        displayQuotes(quotes);
    };

    // Function to edit a quote
    window.editQuote = function (id) {
        let quotes = getQuotesFromStorage();
        const quoteToEdit = quotes.find(quote => quote.id === id);
        quoteText.value = quoteToEdit.text;
        quoteAuthor.value = quoteToEdit.author;
        deleteQuote(id);  // Remove the old quote
    };
});
