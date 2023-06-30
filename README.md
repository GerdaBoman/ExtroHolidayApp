##ExtroHoliday##

ExtroHoliday is a web application designed to help users maximize their annual leave holidays by planning around holidays and weekends. It provides a calendar interface that highlights work-free days in red and recommends days to take off work in yellow, ensuring users can enjoy a minimum of 5 consecutive days off.

Thus us version 1 of the application and it  build with .NET 7 backend and React 18 with Typescript frontend. 

## Project link ##
Visit the ExtroHoliday web application [here](https://extroholiday.azurewebsites.net/).

Azure Pipeline - [here](https://dev.azure.com/bomangerda/ExtroHolidayApp).

## Getting Started ## 

To run the project locally, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution and set `extroholiday.client` as the startup project.
3. Press run or navigate to the terminal and execute `npm i` to install all the necessary dependencies.
4. Start the frontend locally by running the command `npm run build`.

The frontend communicates with the published API in Azure.

 ## To start both Backend and frontend locally##

 To run both the backend and frontend components locally, do the following:

1. Right-click on the solution and select `Configure Startup Projects`.
2. Choose `Multiple startup projects`.
3. Set `extroholiday.api` and `extroholiday.client` as the startup projects.
4. Save the configuration and run the application.

Please note that in the frontend, you need to update the fetch URL in `line 66` of the `src/Pages/Planner.tsx` file in the `extroholiday.client` to `https://localhost:7143/api/Calendar?year=` for local testing purposes.

## Technologies Used ##

ExtroHoliday utilizes the following technologies:

- Backend: .NET 7

- Frontend: React 18 with Typescript

Feel free to reach out if you have any questions or need further support!
