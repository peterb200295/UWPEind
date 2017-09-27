Functions General
- Responsive
- Works on all devices
- Error handling, may not crash for example when no internetconnection is established
- Back button must be present for phones 
V MVVM pattern must be implemented

Functions Mainpage
V Must show a list of articles, most recent at the top
V List should be listview with incremental loading
V Of each article at least the picture and title must be shown
V When clicking an article the application navigates the user to article detail page
- User should be abled to log in
- When logged in, the user is provided a way to like articles

Functions Detailpage
V Of the article the following must be shown: title, description, image, full article url
- The page must implement scrolling
V Full article url should be clickable and should open the url in default browser
V Back button should be a way to return to mainpage, not make a new instance of the mainpage

Functions Optional
- Create a way for the user to refresh the articles on the main page (pull to refresh, or some other way to refresh)  0.5
- Allow the user to see a list of all his/her favorite articles (when the user is logged in) +1 
- When the user is logged in, allow the user to log out. +0.5 
- Store the users credentials in a secure manner, so the user does not need to log in every time the app starts. 
	Remember to clear the stored credentials when the user logs out. +1 
- Allow a user to register a new account. +0.5 
- Allow the user to filter the articles based on news feed. +1 
- On the details page, show all properties of an article (timestamp, related articles, categories) +0.5 
- On the details page, allow the user to select a category. When the user selects a category, a list of articles 
	must be shown that all belong to that category. Clicking on an article in that list shows the details of that article. 
	Navigation in the app becomes more complicated with this feature, but navigation must still be functional. +2 
- Create a live tile that is updated from a background task. +2  
- Make sure that the app correctly handles suspension (backgrounding). 
	When the app is resumed, the app should continue as if nothing has happened. +1 
- Localize the app for another language. +0.5  
- Show some indicator (spinner or progress bar) when the app is communicating with the backend, 
	so the user knows that the app is doing something. +0.5 
- Allow the user to share an article, using the OS-provided sharing functionality. +1  
- Create a nice app icon (tile image) and splash screen. +0.5 
- Any other feature you can think of to improve this app. Will be rewarded based on complexity of the feature. 