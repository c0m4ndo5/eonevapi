# eonev

Coding Challenge for a hiring process. This is the back end project.

## Running the project

### Prerequisites

.NET Core SDK 3+ https://dotnet.microsoft.com/download/dotnet-core/3.0

node v12+ (LTS version recommended) https://nodejs.org/en/download/

### 1. Download/clone both the back end (this project) and the frint end (https://github.com/c0m4ndo5/eonev)

They should be on separate folders

### 2. Go to the API folder (eonevapi) and run dotnet run --project .\eonev.api\eonev.api.csproj

Optionally, you may run dotnet test to run the unit tests before.

### 3. Navigate to the front end folder (eonevapp) and run npm install

Wait for dependencies to install

### 4. Then, in the same folder, run npm start.

View the event viewer at http://localhost:3000/eventviewer
Note: Use Chrome due to https://github.com/facebook/create-react-app/issues/8084#issuecomment-562981098 in development mode

Basic API swagger documentation at http://localhost:5000/swagger/index.html
