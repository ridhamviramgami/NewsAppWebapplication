let currentPage = 1;
let pageSize = 5; // Default page size
let searchQuery = 'Times of India'; // Default search query
let language = ''; // Default language (all languages)
let sortBy = 'publishedAt'; // Default sort option
let totalResults = 0; // Total number of results


//let apikey = "6953ea382486420d83efb8ee4c629616"; //api key
let apikey = "222a6988d2c44e05ab11aaaaf619e4e0"; //api key


const FetchNews = async (page) => {
    console.log("fetching news...");

    // Get today's date
    const today = new Date();
    const toDate = new Date(today);
    toDate.setDate(today.getDate());
    const fromDate = new Date(toDate);
    fromDate.setDate(toDate.getDate() - 15);

    const formatDate = (date) => {
        return date.toISOString().split('T')[0]; // Convert to ISO format and extract the date part
    };

    const fromDateString = formatDate(fromDate);
    const toDateString = formatDate(toDate);

    const url = `https://newsapi.org/v2/everything?q=${encodeURIComponent(searchQuery)}&from=${(fromDateString)}&to=${(toDateString)}&pageSize=${pageSize}&language=${language}&page=${page}&sortBy=${sortBy}&apiKey=${apikey}`;
    let response = await fetch(url);
    let data = await response.json();
    console.log(data);

    totalResults = data.totalResults;
    document.getElementById("resultcount").innerHTML = totalResults;

    let str = "";
    for (let item of data.articles) {
        str += `
                            <div class="col-12 col-md-6 col-lg-4 mb-4">
                                <div class="card custom-card" style="height: 100%; display: flex; flex-direction: column;">
                                    <img src="${item.urlToImage}" class="card-img-top" alt="${item.title}" style="object-fit: cover; height: 200px;">
                                    <div class="card-body d-flex flex-grow-1 flex-column">
                                        <h5 class="card-title">${item.title}</h5>
                                        <p class="card-text" style="flex-grow: 1;">${(item.description)}</p>
                                        <a href="${item.url}" target="_blank" class="btn btn-dark mt-auto">Read full article</a>
                                    </div>
                                </div>
                            </div>`;
    }
    document.querySelector(".content").innerHTML = str;

    // Generate pagination
    generatePagination();
};

const generatePagination = () => {
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = ""; // Clear existing pagination

    const totalPages = Math.ceil(totalResults / pageSize);
    const maxPagesToShow = 5;
    let startPage, endPage;

    if (totalPages <= maxPagesToShow) {
        startPage = 1;
        endPage = totalPages;
    } else {
        if (currentPage <= Math.ceil(maxPagesToShow / 2)) {
            startPage = 1;
            endPage = maxPagesToShow;
        } else if (currentPage + Math.floor(maxPagesToShow / 2) >= totalPages) {
            startPage = totalPages - maxPagesToShow + 1;
            endPage = totalPages;
        } else {
            startPage = currentPage - Math.floor(maxPagesToShow / 2);
            endPage = currentPage + Math.floor(maxPagesToShow / 2);
        }
    }

    // Add previous button
    const prevLi = document.createElement("li");
    prevLi.className = `page-item ${currentPage === 1 ? 'disabled' : ''}`;
    prevLi.innerHTML = `<a class="page-link" href="#" onclick="goToPage(${currentPage - 1})">&lt;</a>`;
    pagination.appendChild(prevLi);

    // Add page number buttons
    for (let i = startPage; i <= endPage; i++) {
        const li = document.createElement("li");
        li.className = `page-item ${i === currentPage ? 'active' : ''}`;
        li.innerHTML = `<a class="page-link" href="#" onclick="goToPage(${i})">${i}</a>`;
        pagination.appendChild(li);
    }

    // Add next button
    const nextLi = document.createElement("li");
    nextLi.className = `page-item ${currentPage === totalPages ? 'disabled' : ''}`;
    nextLi.innerHTML = `<a class=" page-link" href="#" onclick="goToPage(${currentPage + 1})">&gt;</a>`;
    pagination.appendChild(nextLi);
};

const goToPage = (page) => {
    if (page < 1 || page > Math.ceil(totalResults / pageSize)) return;
    currentPage = page;
    FetchNews(currentPage);
};

const setSearchQuery = (query) => {
    searchQuery = query; // Update search query
    document.getElementById("searchInput").value = query; // Update input value
    currentPage = 1; // Reset to first page

    // Update active tab
    document.querySelectorAll('.nav-link').forEach(link => {
        link.classList.remove('active');
    });
    document.querySelector(`a[onclick="setSearchQuery('${query}')"]`).classList.add('active');

    FetchNews(currentPage); // Fetch news with new query
};

document.getElementById("searchForm").onsubmit = (event) => {
    event.preventDefault(); // Prevent form submission
    searchQuery = document.getElementById("searchInput").value.trim() || 'india'; // Update search query
    language = document.getElementById("languageSelect").value; // Update selected language
    sortBy = document.getElementById("sortSelect").value; // Update selected sort option
    currentPage = 1; // Reset to first page
    FetchNews(currentPage); // Fetch news with new query and language
};

document.getElementById("pageSizeSelect").onchange = (event) => {
    pageSize = parseInt(event.target.value); // Update page size
    currentPage = 1; // Reset to first page
    FetchNews(currentPage); // Fetch news with new page size
};

// Initial fetch
FetchNews(currentPage);