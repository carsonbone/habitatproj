

Asset Folder Layout:

	Joystick 
		just the folder that came with the unity joystick pack, nothing of interest unless we change the joystick later
	Resources 
		where prefabs go, maybe other stuff that needs to be loaded
		Unity has a thing about loading several objects and them needing to be in a resources folder so this is just for that to be safe
		
		Prefabs
			the only prefabs we have right now are the test placeable objects, but all placeable objects will eventually go in here
	Scenes 
		the way Unity splits things up, nothing of interest in here rn, will probably change when we need a loading screen
	Scripts
		where scripts go, everything that is actualy code should be created in this folder, then dragged onto the cooresponding gameobject
	Sprite Atlas 
		just a folder to hold the sprite atlas, something Unity likes to have to load all the tiles cohesively
	Sprites
		right now just has character sprites in it, and the cooresponding animation files
		once we figure out character customization this will probably get a loooot larger and more complex

	TextMeshPro
		Unity UI stuff, holds fonts and stuff

	Tiles
		This is where all the tiles we are currently using go, including the actualy tile palette file itself
		Tiles (for the purpose of this project) basically just means ground/water stuff, everything else will most likely be an object/prefab

		Objects
			Has the test object sprites in it right now, when more placeable objects get added, their sprites will go in here
			note: this is not where the prefabs are, just the sprites for the prefabs

Other Notes:
	
	
	if a gameobject is blue that means its a prefab, so everything changed on it will not save
	because its just a copy of an object not the base object
	if you want to change the actual prefab (meaning all copies will be changed)
	you have to find the prefab in the asset folders then double click it to bring up a new space
	it will update all existing and future prefabs of that object
	this includes adding scripts/ changing public variables

	the objecthandler gameobject holds the code for dragging objects 
	it will eventually hold the code for placing and interacting with UI probably 

	the canvas object is tied to the event system object so dont delete that even though it doesnt do anything rn
	the canvas will be the parent for everything UI related, including the joystick
	so make sure ui elements are always a child of it

	when not doing maximize on play, UI elements will probably look weird
	so just check how it looks maximized and with scale 1x

	the grid is seperated into ground/water
		ground can be walked on, water cannot
			(meaning ground has no collision while water does)
		once we finish the layout of the island the tiles will need to be repainted
		if water is drawn overlapping with ground it will make the player not able to walk there

	character movement speed can be changed, its at 300 right now which is probably too slow for testing stuff
	
	when making box colliders for placeable objects, when we start adding new ones, make sure the top of the collider is lower than
	the actual sprite, this is bc the player's collider is lower than its sprite so he can walk onto the bottom edge of ground-to-water tiles


	if yall have any questions about how stuff is set up right now or some more general Unity questions let me know

