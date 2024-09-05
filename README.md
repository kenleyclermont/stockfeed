# StockFeed

## Use Cases 

### Internet Connection

![stockfeed logo](https://github.com/kenleyclermont/stockfeed/blob/master/view_internet.gif)

### No Internet Connection

![internet connection failure](https://github.com/kenleyclermont/stockfeed/blob/master/view_nointernet.gif)

### Internet Reload

![stockfeed logo](https://github.com/kenleyclermont/stockfeed/blob/master/view_internetreload.gif)

## Overview

StockFeed is a .NET MAUI app that displays real-time stock data for companies, using the Alpha 
Vantage API. The app is designed with a clean and intuitive user interface built using XAML.

## Features

- View stock details (price, volume, open, close, etc.) for selected companies.
- Cross-platform compatibility with Xamarin.Forms.
- Simple navigation with retry options for internet issues.

## User Stories

- **Main Interface**: Start the app and click "View Companies" to access stock data.
- **Companies Interface**: Search and select a company, or cancel to return to the main screen.
- **Selected Company Interface**: View detailed stock data for the chosen company. Clicking the 
company’s logo image navigates back to the Companies Interface.
- **Internet Reload Interface**: Retry loading data or cancel and return to the Companies Interface 
if internet is unavailable.


## Credits
This project is created by Kenley Clermont and is open-source under the [MIT License](https://github.com/kenleyclermont/Scratch/blob/main/LICENSE).

Special thanks to [Alpha Vantage](https://www.alphavantage.co/) for providing financial data APIs.

The full text of the MIT License can be found [here](https://opensource.org/licenses/MIT).

