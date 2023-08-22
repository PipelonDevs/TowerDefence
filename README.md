
# Tower Defense Game Documentation  
## Table of Contents  
1. [Introduction](#introduction) 
2. [Folder structure](#folder-structure)
3. [Game Mechanics](#game-mechanics) 
	- [Enemies](#enemies) 
	- [Towers](#towers) 
	- [Resources](#resources)
  	- [Map generation](#map-generation)
  	- [Trolley](#trolley)
  	- [City](#city)
4. [Level Design](#level-design)
  	- [Main rules of levels](#level-rules)
  	- [List of levels](#level-list)
5. [User Interface](#user-interface) 
	- [Main Menu](#main-menu) 
	- [In-Game HUD](#in-game-hud) 
6. [Controls](#controls) 
7. [Settings](#settings) 
8. [Conventions](#conventions)
 	 - [C# Code](#cs-code)
9. [Packages](#packages)
	- [AI Navigation](#ai-navigation)
 	- [Cinemachine](#cinemachine)
  	- [Input System](#input-system)
   	- [Post Processing](#post-processing)
   	- [Shader Graph](#shader-graph)
   	- [Splines](#splines)
   	- [TextMeshPro](#textmeshpro)
   	- [Universal RP](#urp)
   	- [Visual effect graph](#vfx-graph)
10. [Architecture](#architecture)
	- [Singleton](#singleton)
11. [FAQs](#faqs) 

## 1. Introduction <a name="introduction"></a> 
### Welcome to the Tower Defense game documentation. This document provides an overview of the game's features and how to play. 

## 2. Folder structure <a name="folder-structure"></a> 
### Below there is an image but also a short description of basic folder structure

![image](https://github.com/PipelonDevs/TowerDefence/assets/95643408/fe61b5ae-94b6-499d-a3d9-788153359e54)

- Art

   - Animations: Contains animated assets for the game.
   - Materials: Stores material files used to define the appearance of 3D models.
   - Meshes: Holds 3D model files representing objects, characters, etc.
   - Particles: Contains particle effects used for various in-game visual elements.
   - Sprites: Contains 2D image files representing sprites or icons.
   - Textures: Stores texture files used for 3D models or environment mapping.
   - UI: Contains user interface-related graphical assets.
   - VFX: Holds visual effects files used for in-game special effects.
   - AssetsExt: Reserved for external or third-party assets that are not part of the core development.

- Audio
   - Music: Contains music tracks or soundtracks for the game.
   - Sounds: Holds individual sound effects used in the game.

- Code
   - Scripts: Contains code files, such as scripts written in the programming language used for the game logic.
   - Shaders: Holds shader code files used for controlling how materials are rendered.

- Docs: Reserved for documentation files related to the game.

- Level
   - Prefabs: Contains prefabricated or reusable assets representing in-game elements.
   - Scenes: Holds scene files defining various game levels or environments.
   - Misc: Reserved for any miscellaneous files or assets that don't fit in other categories.
     
- Sandbox: A playground to test out ideas (please clear after being finished with tests and reorganizing used stuff)

## 3. Game Mechanics <a name="game-mechanics"></a> 
  ### 3.1 Enemies <a name="enemies"></a> 
Describe various types of enemies, their strengths, and weaknesses. Provide information on enemy behavior and how they interact with towers. 
  ### 3.2 Towers <a name="towers"></a> 
List the available towers in the game, their unique abilities, and upgrade paths. Explain the tower placement and targeting mechanics. 
### 3.3 Economy and resources <a name="resources"></a> 
Explain the resources players can earn or spend, such as in-game currency for purchasing towers and upgrades. 
### 3.4 Map generation <a name="map-generation"></a>
Describe the process of map generation, its variability and usage examples
### 3.5 Trolley <a name="trolley"></a>
Describe the trolley movement, its interactions with environment and enemies
### 3.6 City <a name="city"></a>
List the available actions in the cities, types of cities, explain the interactions with NPCs
## 4. Level Design <a name="level-design"></a> 
Explain the process of creating and designing game levels. Discuss different types of terrains, obstacles, and strategies for level progression. 
### 4.1 Main rules of levels <a name="level-rules"></a> 
Describe the rules that levels need to follow and fundamental objects in them
### 4.2 List of levels <a name="level-list"></a> 
Example levels and list of already created levels
## 5. User Interface <a name="user-interface"></a> 
### 5.1 Main Menu <a name="main-menu"></a> 
Detail the options available on the main menu, such as starting a new game, accessing settings, or loading a saved game. 
### 5.2 In-Game HUD <a name="in-game-hud"></a> 
Explain the in-game heads-up display (HUD) elements, including resource indicators, wave counter, and tower information. 
## 6. Controls <a name="controls"></a> 
List and explain the controls required to play the game, such as placing towers, upgrading towers, and navigating the game menus. 
## 7. Settings <a name="settings"></a> 
Describe the various settings and options available to players, such as sound controls, graphics settings, and key bindings. 
## 8. Conventions <a name="conventions"></a>
### 8.1 C# Code <a name="cs-code"></a>
- PascalCase for public methods 
- _camelCase for private methods and properties
- camelCase for public properties and local variables
- UPPER_CASE for constants
## 9. Packages <a name="packages"></a>
### 9.1 AI Navigation <a name="ai-navigation"></a>
AI navigation provides AI navigation features, enabling pathfinding and navigation for game entities. 
### 9.2 Cinemachine <a name="cinemachine"></a>
Cinemachine is a powerful camera system that helps you create dynamic and cinematic camera movements. 
### 9.3 Input System <a name="input-system"></a>
The Input System package offers a flexible and efficient way to handle player input.
### 9.4 Post Processing <a name="post-processing"></a>
Post processing enables you to apply post-processing effects to your game's visuals. 
### 9.5 Shader Graph <a name="shader-graph"></a>
Shader Graph is a tool that allows you to create shaders visually, without writing code. 
### 9.6 Splines <a name="splines"></a>
The Spline package helps you create and manipulate splines, which are essential for creating curved paths and trajectories in your game.
### 9.7 TextMeshPro <a name="textmeshpro"></a>
TextMesh Pro is an advanced text rendering package that offers improved text quality and flexibility over Unity's built-in text system.
### 9.8 Universal Render Pipeline <a name="urp"></a>
The Universal Render Pipeline package provides a high-quality, performant rendering solution for various platforms. 
### 9.9 Visual effect graph <a name="vfx-graph"></a>
The Visual Effect Graph allows you to create complex visual effects using a node-based graph system.
## 10. Architecture <a name="architecture"></a>
### 10.1 Singleton <a name="singleton"></a>
- Singleton Base Class:
This is a generic base class, named Singleton, that allows you to implement the Singleton design pattern for any MonoBehaviour-derived class. It ensures that only one instance of the provided class exists in the scene. INSTANCE REFERENCE IN UNITY INSPECTOR CHANGES ON SCENE LOAD THUS TO HAVE E.G. BUTTON USING THIS OBJECT YOU NEED TO WRITE SCRIPT THAT ADDS EVENT LISTENER AND DYNAMICALLY ADDS EXISTING REFERENCE AT RUNTIME, OTHERWISE AFTER FIRST SCENE LOAD NEW REFERENCES WILL BE MISSING IN BUTTON'S INSPECTOR
Example usage:
Inheritance:

		public class SceneHandler : Singleton<SceneHandler>

Calling singleton (SceneHandler singleton):

		SceneHandler.Instance.func()
  		
  
- SceneHandler
This class, named SceneHandler, inherits from the previously defined Singleton<SceneHandler> class. It represents a manager for handling scene transitions and quitting the game.

- SingletonsHolder
This class, named SingletonsHolder, inherits from the Singleton<SingletonsHolder> class as well. It acts as a placeholder to hold and manage other singleton instances in your game. 
		
## 11. FAQs <a name="faqs"></a> 
Anticipate common questions players might have and provide answers to them here. 
