# Task
The Hacker News API is documented here:
https://github.com/HackerNews/API
.
The IDs for the "best stories" can be retrieved from this URI:
https://hacker-news.firebaseio.com/v0/beststories.json
.
The details for an individual story ID can be retrieved from this URI:
https://hacker-news.firebaseio.com/v0/item/21233041.json
(in this case for the story with ID
21233041
)
The API should return an array of the first
n
"best stories" as returned by the Hacker News API, sorted by their score in a descending order.

In addition to the above, your API should be able to efficiently service large numbers of requests without risking overloading of the Hacker News API.
You should share a public repository with us, that should include a README.md file which describes how to run the application, any assumptions you have made, andany enhancements or changes you would make, given the time.



# Hacker News Best Stories API

This project is an ASP.NET Core application that provides a RESTful API to retrieve the details of the first `n` best stories from the Hacker News API. The number of stories to retrieve is specified by the caller to the API.

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- An internet connection to access the Hacker News API

### Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/your-username/hacker-news-api.git
2.Navigate to the project directory:

	cd hacker-news-api

3. Restore the dependencies:
			
	dotnet restore

### Running the Application

1. Build the project:
	
	dotnet build

2.Run the project: 

	dotnet run

3. The API will be available at https://localhost:5001 or http://localhost:5000.


### Usage
To fetch the top n best stories from Hacker News, make a GET request to the following endpoint:
	
	GET /api/hackernews/beststories?n={number_of_stories}

Example Request

	GET /api/hackernews/beststories?n=10

Example Response

	[
	  {
		"by": "poidos",
		"descendants": 535,
		"id": 41146239,
		"score": 1537,
		"time": 1722687963,
		"title": "\"We ran out of columns\"",
		"type": "story",
		"url": "https://jimmyhmiller.github.io/ugliest-beautiful-codebase"
	  },
	  {
		"by": "clownstrikelol",
		"descendants": 227,
		"id": 41133917,
		"score": 1215,
		"time": 1722548300,
		"title": "CrowdStrike representatives issue trademark infringement notice to ClownStrike",
		"type": "story",
		"url": "https://clownstrike.lol/crowdmad/"
	  },
	  // more stories...
	]



### Project Structure
	- Program.cs: Entry point of the application. Configures services and the HTTP request pipeline.
	- Controllers/HackerNewsController.cs: Defines the API endpoints.
	- Services/HackerNewsService.cs: Contains the business logic for fetching data from the Hacker News API.
	- Models/Story.cs: Defines the model for a story from Hacker News.

### Logging
	- The application uses the built-in logging framework of ASP.NET Core. Logs are written at various stages of the process, including fetching data, processing IDs, and handling errors.

### Dependencies

	- System.Net.Http
	- Newtonsoft.Json
	- Microsoft.Extensions.Logging

### License
This project is licensed under the MIT License. See the LICENSE file for details.

### Acknowledgments
	- Hacker News API for providing the data.

### Contributing
	1. Fork the repository.
	2. Create a feature branch (git checkout -b feature/my-feature).
	3. Commit your changes (git commit -am 'Add new feature').
	4. Push to the branch (git push origin feature/my-feature).
	5. Create a new Pull Request.
	vahanhakobyan@yahoo.com

### Contact
For any issues or questions, please open an issue on this repository or contact me at vahanhakobyan@yahoo.com
