# Scrubber
Allows you to open any scriptable object in an editor window 
![Imgur]https://i.imgur.com/IZ49lA8.png
![Imgur]https://i.imgur.com/9ItVxkB.png

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

#### Option A
![Imgur](https://i.imgur.com/2gcNS3G.png)
1. Make a script that inherits from Scriptable Object
2. Add either ScrubData or FancyScrubData attribute on top
3. Double-click the ScriptableObject file in the project view
4. A window will open with your scriptable object data

#### Option B
![Imgur](https://i.imgur.com/uKSn3E5.png)
1. Right click a scriptable object asset in the project view
2. Select "Scrubber/Open with Fancy Scrubber Window"
3. A window will open with your scriptable object data