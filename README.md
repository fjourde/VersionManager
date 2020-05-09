# Version Manager

Version Manager allow you do display key features of each versions 
of you asp.net core application.

# Quick Start

1. Add VersionManager Nuget package to you web application project.
2. Create a file named "versions.json" a root of your projet.
3. In a cshtml file, use <website-version> tag to display app version.

## 1. Add Nuget Package

Add VersionManager Nuget package to you web application project.

## 2. Create versions file 

On the root directory of your web application project, 
create a file named "versions.json" witch contain version definition

	[
	  {
		"Id": "1.0.0",
		"Date": "01/01/2020",
		"Value" : "Fisrt public release"
		"Items": [
		  "Description of key feature 1",
		  "Description of key feature 2",
		  "Description of key feature 3"
		]
	  },
	  {
		"Id": "1.1.0",
		"Date": "07/02/2020",	
		"Items": [
		  "Description of key feature 4",
		  "Description of key feature 5",
		]
	  },
	]


## 3. Use Tag Helper 

In the .cshtml file where you would like to display version, use the following tag

	<website-version>
	
The tag will produce code like that compatible with BootStrap 4.+

	<div class="">
		<span class="badge badge-secondary">{Date}</span>
		<span class="badge badge-primary ml-1">{Id}</span>
		<span class="text-muted ml-1">{Value}</span>
		<ul class="">
			<li class="">{Items.0}</li>
			<li class="">{Items.1}</li>
			<li class="">{Items...}</li>
		</ul>
	</div>

# Customization

## 1. Version File

You can define a different location and name for "version" file.
	<website-version file="/location/custom-version-file.json">

## 2. Appearance

You can customize appearance of the html result in changing class of each element.
Just add one of both attribute.

* div-class
* id-class
* date-class
* value-class
* ul-class
* li-class

for example : 

	<website-version div-class="bg-dark" date-class="badge-info" />






