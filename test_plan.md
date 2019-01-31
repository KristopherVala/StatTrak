# Test Plan
Website Url: https://stattrak.azurewebsites.net/

Instructions:
Divide your system into areas or components in whatever way makes sense for your particular system—for example, business area, use case, and so on.

Create a table as in the example below, showing the test cases and expected results for each function in each area/segment of your system. You should have several tables.

Please note the level of detail—these are not scenarios, simply higher level test cases. The example is just an example—do not include it in your test document.

**Area: Registration and Login**

|   | Function | Case | Result |
| --- | --- | --- | --- |
| 1 | Log in | Admin role, Success | User is allowed access into the system. Admin dashboard is displayed. |
|   |   | Regular role, Success | User is allowed access into the system. User profile information is displayed. |
|   |   | Password does not match ORUser id does not match | Error, user is not logged in. |
| 2 | Forgot Password | Success | System sends email, user enters correct pin code from email and is able to access system |
|   |   | Failure | System sends email, user enters incorrect pin code from email. User is not able to access system. Error. |
| 3 | Register | Regular role, Success | User information is saved and user is able to log in after confirming email. |
|   |   | Regular role, failure—one or more fields missing or incorrect. | Error. |

**Area: Upload Game Data**

|   | Function | Case | Result |
| --- | --- | --- | --- |
| 1 | Log in | Admin role, Success | User is allowed access into the system. Admin dashboard is displayed. |
|   |   | Regular role, Success | User is allowed access into the system. Home Page is displayed. |
|   |   | Password does not match OR User id does not match | Error, user is not logged in. |
| 2 | View Game | Success | Display leaderboard for requested game. |
| 3 | Upload data for game | Regular role, Success | User is directed to upload page where they can input and upload statistic data. |
|   |   | Regular role, Failure -- user is not logged in | User is directed to log-in page where they can also register. |
| 4 | Save Changes | Success – all entries pass validation | Changes are saved to database and user is redirected to view profile page. |
|   |   | Failure – data entries do not pass validation | Changes are not saved, and user is prompted to enter information again with relevant errors shown. |

**Area: View User Profile**

|   | Function | Case | Result |
| --- | --- | --- | --- |
| 1 | Log in | Admin role, Success | User is allowed access into the system. Admin dashboard is displayed. |
|   |   | Regular role, Success | User is allowed access into the system. User profile information is displayed. |
|   |   | Password does not match ORUser id does not match | Error, user is not logged in. |
| 2 | View User List | Success | User is directed to list of StatTrak users. |
|   |   | Failure, User is not logged in. | User is directed to log-in page where they can also register. |
| 3 | Choose Profile to View | Regular role, Success | User is shown profile page with Display picture, display name, first name and age.  User can also view the last time this profile logged into the website. |
|   |   | Admin role, Success | Admin is shown profile page with Display picture, display name, first name and age.  User can also view the last time this profile logged into the website.  Admin can also edit this profile. |


**Area: Edit game data**

|   | Function | Case | Result |
| --- | --- | --- | --- |
| 1 | Log in | Admin role, Success | User is allowed access into the system. Admin dashboard is displayed. |
|   |   | Regular role, Success | User is allowed access into the system. User profile information is displayed. |
|   |   | Password does not match ORUser id does not match | Error, user is not logged in. |
| 2 | View game list | Success | User is shown list of games that the system provides. |
| 3 | Choose game | Success | User is directed to the leaderboards for chosen game. |
| 4 | Edit statistics | Regular role, Success, statistic being edited is tied to the account of editing user. | User is directed to the edit page where they can edit their statistic entry associated with the game who&#39;s leaderboard they are on. |
|   |   | Regular role, failure— User is cannot edit data that is not theirs. |   |
|   |   | Admin role, success— Admin can edit any statistic | Admin is directed to the edit page where they can edit their statistic entry associated with the game whose leaderboard they are on. |
| 5 | Save Changes | Success – all entries pass validation | Edited statistics are saved to the database and user is redirected to game leaderboards. |
|   |   | Failure – data entries did not pass validation | Changes are not saved, and user is prompted to enter information again with relevant errors shown. |

**Area: Edit user data**

|   | Function | Case | Result |
| --- | --- | --- | --- |
| 1 | Log in | Admin role, Success | User is allowed access into the system. Admin dashboard is displayed. |
|   |   | Regular role, Success | User is allowed access into the system. User profile information is displayed. |
|   |   | Password does not match ORUser id does not match | Error, user is not logged in. |
| 2 | View user list | Success | User is shown list of profiles that the system provides. |
|   |   | Failure, user is not logged in. | User is directed to log-in page where they can also register. |
| 3 | Choose Profile to view | Regular role, Success to the account of editing user. | User is shown profile page with Display picture, display name, first name and age.  User can also view the last time this profile logged into the website. |
|   |   | Admin role, Success | Admin is shown profile page with Display picture, display name, first name and age.  User can also view the last time this profile logged into the website.  Admin can also edit this profile. |
| 4 | Edit User | Regular Role, Success – The user information being edited is by the same user editing. | User is re-directed to the edit user page where they can edit Display picture, display name, first name, last name and age. |
|   |   | Regular Role, Failure – Users cannot edit information that is not theirs |   |
|   |   | Admin Role, Success | Admin is re-directed to the edit user page where they can edit Display picture, display name, first name, last name and age. |
| 5 | Save Changes | Success – all entries pass validation | Edited statistics are saved to the database and user is redirected to game leaderboards. |
|   |   | Failure – data entries did not pass validation | Changes are not saved, and user is prompted to enter information again with relevant errors shown. |


**Area: Change password**

|   | Function | Case | Result |
| --- | --- | --- | --- |
| 1 | Log in | Admin role, Success | User is allowed access into the system. Admin dashboard is displayed. |
|   |   | Regular role, Success | User is allowed access into the system. User profile information is displayed. |
|   |   | Password does not match ORUser id does not match | Error, user is not logged in. |
| 2 | Access account settings | Success | User is re-directed to the account settings page. |
|   |   | Failure, user is not logged in. | User is directed to log-in page where they can also register. |
| 3 | Change password | Regular role, Success - User enters a valid new password that matches the confirmed password, as well as correctly enters old password.  User must also have a confirmed email. | User&#39;s password is updated and message is shown in green to confirm. |
|   |   | Regular role, Failure – User enters invalid old password, new passwords do not match/follow rules, or user does not have a confirmed email. | User is prompted to re-enter information with errors on where the process failed. |

**Area: Browse Game Details**

|   | Function | Case | Result |
| --- | --- | --- | --- |
| 1 | Log in | Admin role, Success | User is allowed access into the system. Admin dashboard is displayed. |
|   |   | Regular role, Success | User is allowed access into the system. User profile information is displayed. |
|   |   | Password does not match ORUser id does not match | Error, user is not logged in. |
| 2 | View game list | Success | User is shown list of games that the system provides. |
| 3 | Choose More Info to see details of chosen game | Success | User is directed to the game details page of the chosen game. |
| 4 | View screenshots of chosen game | Success, User chooses screenshot 1 | System displays first screenshot on the screen as well as the information about the game. |
|   |   | Success, User chooses screenshot 2 | System displays second screenshot on the screen as well as the information about the game. |
|   |   | Success, User chooses screenshot 3 | System displays third screenshot on the screen as well as the information about the game. |
|   |   | Success, User chooses screenshot 4 | System displays fourth screenshot on the screen as well as the information about the game. |
| 5 | Link to website to purchase game | Success | User is re-directed to the website of chosen game where they can purchase and/or download. |
