// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//document.addEventListener('DOMContentLoaded', function () {
//    var searchForm = document.getElementById('searchForm');
//    var searchInput = document.getElementById('searchInput');
//    var searchButton = document.getElementById('searchDropdown');
//    var searchType = 'name'; // Default search typethe

//    // Event listener for dropdown items
//    document.querySelectorAll('.search-option').forEach(function (option) {
//        option.addEventListener('click', function (event) {
//            event.preventDefault();
//            searchType = this.getAttribute('data-search-type');
//            // Set the button text to the selected search type
//            searchButton.textContent = this.text;
//            // Trigger the search
//            searchButton.click();
//        });
//    });

//    // Main search button event
//    searchButton.addEventListener('click', function (event) {
//        if (!event.detail || event.detail == 1) { // Check if the button is clicked directly
//            var searchTerm = searchInput.value.trim();
//            if (!searchTerm) {
//                // No search term entered, possibly handle error
//                return;
//            }

//            // Create the URL and perform the search
//            var url = `https://localhost:7059/products/${searchType}?=${encodeURIComponent(searchTerm)}`;
//            window.location.href = `https://localhost:7129/Index?searchType=${searchType}&=${encodeURIComponent(searchTerm)}`;
//        }
//    });

//    // Optional: To handle form submission if Enter is pressed
//    searchForm.addEventListener('submit', function (event) {
//        event.preventDefault();
//        searchButton.click();
//    });
//});

document.addEventListener('DOMContentLoaded', function () {
    // Update hidden input when selecting a search option
    document.querySelectorAll('.search-option').forEach(function (item) {
        item.addEventListener('click', function (event) {
            event.preventDefault();
            var searchTypeInput = document.getElementById('searchTypeInput');
            if (this.id === 'searchByName') {
                searchTypeInput.value = 'name';
            } else if (this.id === 'searchByCategory') {
                searchTypeInput.value = 'category';
            }
            // Then submit the form
            document.getElementById('searchForm').submit();
        });
    });
});

