# MinimalApi
A beer api with login and jwt written in asp.net

## Envoriment

 . Visual Studio 2022
 
 . .Net 6
 
## Packages

. BCrypt.Net-Net 4.0.2

. JWT 8.9.0

. Entity Framework 6.0.1

. Entity Framework Tools 6.0.1

## Routes

### Beer's routes: 

 .  Get http://localhost:8000/api/beer : get a beer list. Needs one parameter by header request: Authorization(token). Returns a beer list.  
 
 .  Post http://localhost:8000/api/beer : storages a beer. Needs one parameter by header request and four parameters by body request: Authorization(token) by header request,
 and company(string), alcohol(integer), length(integer) and name(string) by body request. Returns an object with a message.
 
 .  Put http://localhost:8000/api/beer : storages a beer. Needs one parameter by header request and five by body request: Authorization(token) by header request,
 and id(int), company(string), alcohol(int), length(int) and name(string) by body request. Returns an object with a message.
 
 . Delete http://localhost:8000/api/beer : deletes a beer. Needs one parameter by header request and one by query parameter: Authorizarion(token) by header request 
 and id(int) by query parameter. Returns an object with a message.
 
 ### User's routes: 
 
 . Post http://localhost:8000/api/users/register : register an user. Needs four parameters by body request: name(string), lastname(string), email(string) and password(string) by body request.
 Returns an object with a message.
 
 . Post http://localhost:8000/api/users/auth : auth an user. Needs two parameters by request: email(string) and password(string) by body request. Returns an object with a message and a token.
 
 
 
