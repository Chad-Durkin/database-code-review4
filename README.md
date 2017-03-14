# Band Tracker

https://github.com/Rafeekey/database-code-review4.git

A website that keeps track of bands and venues, 3/3/2017

## By Chad Durkin

# Description

This website will allow the user to add bands and venues to the list, as well as let the user add bands to venues, and also choose bands to play at venues. It has updating/deleting functionality.

# Setup/Installation Requirements

* _Open PowerShell_
* In SQLCMD:
* __> CREATE DATABASE band_tracker;__
* __> GO__
* __> USE band_tracker;__
* __> GO__
* __> CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));__
* __> CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255));__
* __> CREATE TABLE bands_venues (id INT IDENTITY(1,1), bands_id INT, venues_id INT);__
* __> GO__
* Clone this directory and navigate to this directory folder on your local machine's Windows PowerShell Run the command "dnu restore"
* Run the command "dnx kestrel"
* Copy and paste the link "localhost:5004" into your browser

# Specifications

* Create a band_tracker database
* Create a bands and venues table inside the band_tracker DATABASE
* Create a DeleteAll() method for each class
* Create a GetAll() method for clients and stylists
* Create an override bool Equals method for both classes
* Create a Save functionality for both classes, that saves to the DATABASE
* Create Find functionalities, by id, for both classes, that searches through the DATABASE
* Create a GetBands() method to be able to search and retrieve all the bands for a specific venue
* Create a GetVenues() method to be able to search and retrieve all the venues for a specific band
* Create an Update functionality to be able to change a band's name in the DATABASE
* Create an Update functionality to be able to change a venue's name in the DATABASE
* Create a Delete Functionality to be able to delete a specific band from the DATABASE
* Create a Delete Functionality to be able to delete a specific venue from the DATABASE

# Bugs

None so far

# Support and Contact Details

For any questions and comments please contact Chad Durkin at Chaddurkin@gmail.com

# Technologies Used

* HTML
* CSS
* MATERIALIZE
* C#
* SQL
* NANCY
* RAZOR

# License

This software is licensed under the GPL license.

Copyright (c) 2017 Chad Durkin
