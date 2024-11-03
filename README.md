# Order Management System

This project is an Order Management System consisting of a Web App Frontend and a Web Service API. It allows users to manage orders and includes functionality for importing data from a JSON file.

## Project Structure

- **WebAppFrontend**: The frontend application for user interaction.
- **WebServiceAPI**: The backend service that handles API requests.
- **convent_json.py**: A Python script used to convert JSON data to the appropriate date format for database storage.

## Prerequisites

Before you begin, ensure you have the following installed:

- .NET SDK (for the WebAppFrontend and WebServiceAPI)
- Python (for the `convent_json.py`)
- SQL Server (or any SQL database you choose)

## Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/your-repo-name.git
   cd your-repo-name
   ```

2. **Configure Database Connection**
   - Connect to your SQL Server on your local machine.
   - Update the configuration files in both the `WebAppFrontend` and `WebServiceAPI` to point to your local database.

3. **Run the Applications**
   - Start the Web Service API:
     ```bash
     cd WebServiceAPI
     dotnet run
     ```
   - Start the Web App Frontend:
     ```bash
     cd WebAppFrontend
     dotnet run
     ```

4. **Convert and Import Data**
   - Use `convent_json.py` to convert your JSON file to the required format. You can run the script as follows:
     ```bash
     python convent_json.py path/to/your/input.json path/to/converted_data.json
     ```
   - Use Postman or any API testing tool to import the converted data. Make a POST request to the following API endpoint:
     ```
     https://localhost:5001/api/order/bulk
     ```
   - In the body of the request, include the contents of `converted_data.json`.

## Notes

- Make sure to replace the API URL in your requests as needed.
- This repository does not include the database due to size constraints, so you'll need to set that up locally.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

- Special thanks to everyone who contributed to this project.