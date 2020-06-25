# Scrubber
Allows you to open any scriptable object in an editor window 

## Prerequisites
Unity 2018.3 and up

## Install

### Unity 2019.3
1. Open the package manager and point to the repo URL

![Imgur](https://i.imgur.com/iYGgINz.png)

### Before Unity 2019.3

#### Option A
1. Open the manifest
2. Add the repo URL either via https or ssh

#### Option B
1. Clone or download the project zip
2. Copy the repo there inside your project's Assets folder

## Usage
1. Make a script that inherits from Scriptable Object
2. Implement either IScrubData or IFancyScrubData
3. Double-click the ScriptableObject file in the project view
4. A window will open with your scriptable object data