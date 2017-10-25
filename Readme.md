# FriendNet
## Overview
Renren is a website like facebook in China. My friend sells foreign cigarette and let me help him advertise on Renren. This software is used to automatically add friends and friends of these friends and so on. In this way, may people can see the advertisements I post on the website.

## Programming Language
This project is written in C#

## Process
### 1. Simualte login
Using Chrome's DevTools to find out the POST request which is used to transmit the login data to the server. Write a method to forge a POST request with the data and save the Cookies in the response.
### 2. Find the firend list
Finding out the url of the friend list and forge a GET request to get friend list. Then using regex parse the HTML extrac the urls which can lead to their homepage.

### 3. Forge add friend request
Find out the POST request used to add friend and forge it.

### 4. Forge the request to make a post
Find out the POST request used to make a post.
