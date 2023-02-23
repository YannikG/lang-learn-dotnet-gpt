# Language Practice Questions Generator
This project uses .NET 7.0, OpenAI API and MongoDB to generate multiple choice questions for language practice. Specifically, it can be used to get auto generated mutlitple choice questions from Chat GPT to practice the following languages: German, English, French, Italian, Ukrainian, Czech, and Spanish. The generated questions are stored in a MongoDB database.

## Installation
To install and run this project, you'll need to have .NET 7.0 installed on your computer, as well as access to an OpenAI API key. Make sure you have generated a random string as UserId (so the AI knows your and don't privde you every time with the same answer).

Add the following two User Secrets:
- OpenAI:ApiKey
- OpenAI:UserId

For local development a connection string to the database is provided.
Make sure you have created the database "questionData" with the collection "multipleChoices" on your MongoDB instance.

## Usage
To run the project, navigate to the project directory in your terminal or command prompt and run the following command:
``
dotnet run
``

Then you can navigate to the following URL in your browser:
``
https://localhost:7198/swagger/index.html
``

## Contributing
Contributions are welcome! If you find a bug or have a feature request, please open an issue on GitHub. If you'd like to contribute code, please fork the repository and create a pull request.
