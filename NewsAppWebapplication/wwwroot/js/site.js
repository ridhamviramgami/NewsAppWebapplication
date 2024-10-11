const FetchNews = async (page) => {
    console.log("fetching news...");
    var url = 'https://newsapi.org/v2/everything?' +
        'q=india&' +
        'from=2024-10-09' +
        'pageSize=20&' +
        "lanuage=hi" + 
        'Page=' + page +
        'sortBy=popularity&' +
        'apiKey=6953ea382486420d83efb8ee4c629616';

    var req = new Request(url);

    //let a = await fetch(req)
    //let response = await a.json()
    //Console.log(JSON.stringify(response))

    let response = {
        "Status": 0,
        "Error": null,
        "TotalResults": 2,
        "Articles": [
            {
                "Source": {
                    "Id": "marca",
                    "Name": "Marca"
                },
                "Author": "marca.com",
                "Title": "MARCA America Award Leo Messi: The number 1 among the number 1s",
                "Description": "A change in FC Barcelona, the number 20 jersey is retired, Deco leaves the field and the number 30 jersey, Messi, steps onto the pitch.&quot; No one could have imagined that those",
                "Url": "https://www.marca.com/en/football/mls/2024/10/09/67064b6c46163f6b3a8b459c.html",
                "UrlToImage": "https://phantom-marca.unidadeditorial.es/8f1e88b42097ecfea476bd011f085ce5/resize/1200/f/webp/assets/multimedia/imagenes/2024/10/09/17284660914942.jpg",
                "PublishedAt": "2024-10-09T09:34:23Z",
                "Content": "A change in FC Barcelona, the number 20 jersey is retired, Deco leaves the field and the number 30 jersey, Messi, steps onto the pitch.\" No one could have imagined that those words, spoken by the sta… [+2978 chars]"
            },
            {
                "Source": {
                    "Id": null,
                    "Name": "The Japan Times"
                },
                "Author": "Haitham EL-TABEI",
                "Title": "From boom to budgeting as reality bites for Saudi football",
                "Description": "After a jaw-dropping 2023, Saudi transfer spending slumped from $957 million to $431 million in the latest window.",
                "Url": "https://www.japantimes.co.jp/sports/2024/10/09/soccer/saudi-arabia-soccer-spending-slump/",
                "UrlToImage": "https://www.japantimes.co.jp/japantimes/uploads/images/2024/10/09/426711.JPG?v=3.1",
                "PublishedAt": "2024-10-09T00:30:00Z",
                "Content": "Riyadh A billion-dollar binge that brought some of soccer's biggest names to Saudi Arabia's modest league has given way to a more cautious phase, with spending down dramatically this year.\r\nAfter a j… [+422 chars]"
            }
        ]
    }

    console.log(response);

    let str = ""
    resultcount.innerHTML = response.TotalResults
    for (let item of response.Articles) {
        str = str + `<div class="card my-4 mx-2" style="width: 18rem;">
                                        <img src="${item.UrlToImage}" class="card-img-top" alt="...">
                                        <div class="card-body">
                                            <h5 class="card-title">${item.Title}</h5>
                                            <p class="card-text">${item.Description}</a>
                                            <a href="${item.url}" taget="_blank" class="btn btn-primary">Go somewhere</a>
                                        </div>
                                    </div>`
    }
    document.querySelector(".content").innerHTML = str
    FetchNews(1)
}