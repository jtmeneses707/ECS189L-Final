# Ruined Isles Information #

## Summary ##

**A paragraph-length pitch for your game.**

Overcoming your inhibitions is difficult for anyone, especially for those who have already given up hope on themselves. An unemployed video game addict, Urumir spends his days browsing online forums and replaying the same old games. His days are bleak and dreary, until one day when he makes his daily trip to the local convenience store. There he meets an untimely end against a speeding Subaru, passing away instantly, his trusty tracksuit failing to protect him. The next thing he knows is opening his eyes in an entirely new world - His body no longer the same, instead composed as an adorable slime. Confused, alone, scared, he tentatively explored the new lands around him, and found a warm welcome from the people of the Isles. In their care he finds the know-how and support he needs to survive in an unfamiliar world. With newfound confidence and desire for exploration, Urumir ventured out farther and farther into the world, accumulating new experiences and abilities, realizing how much time he wasted in his previous life. On and on for years he went, until finally, satisfied he saw all there was to see, Urumir began the journey home to the place he first woke. But there he is met with a bleak sight. Alletas the Demon King had ravaged the Isles, razing down entire villages and towns. With his loved ones mercilessly slaughtered and his home destroyed, Urumir's story takes a drastic shift. He looks to redeem the wasted years wallowed away on nothing, fully coming into his own as a man of valor and honor. To avenge his friends, he must cleanse the land of demonic creatures and strike the Demon King Atellas down from his throne.

*Kudo points if you can spot all of the isekai references from two animes!*

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**

When powered up, Urumir is able to maintain a strong form (2 or more hearts), an amalgamation of the beasts he fought and absorbed throughout his adventures. However, when weakened (1 heart left), Urumir powers down and returns to his primal state as a slime with a ferocious bite.
The game currently supports mouse and keyboard input only. By default, Urumir can move left using A or left arrow key, and right using D or right arrow key. He can use also W or the up arrow key to jump, and may press the key once again while airborne to double jump. Left-clicking in Urumir's strong form results in a forward smash which slightly knocks enemies back, while left-clicking in his weak form will result in a melee bite. 
Defeating a Demon King is no easy task, but Urumir has many tools to work with. In Urumir's strong form, he gains extra abilities. He is able to use spacebar to phase, dashing through enemies and environmental obstacles such as fire pits which would normally damage him. He may right-click to shoot a projectile and damage enemies from a distance. He is also able to use D or the down arrow key to perform a down smash.
If a player were to speedrun this game, they would likely want to rush the platforming sections, evade enemies, and utilize Urumir's dashing mechanic as much as possible to cross tough terrain. However, this requires a good grasp of platforming mechanics and precision. An experienced platformer player may be able to get away with this, but they may be easily punished if they fall into water as it results in an instant death, and will need to restart from the beginning of the level. To play it safe, players should defeat all the enemies and take their time traversing through the destroyed land.

**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

### Jerrie Kraus-Liang ###
- *Figma* - To help out Joshua with the Press Kit & Trailer, I created a [figma design](https://www.figma.com/file/LW0nAMa1yMyAFA2dVRh2yf/ECS-189L-Final?node-id=0%3A1) for desktop and mobile. 
- *Level design & fine-tuning* - To help out with the game design, I first created rough sketches on paper with what the level would be laid out like. The [first sketch](https://user-images.githubusercontent.com/15057519/121359773-71683a00-c8f9-11eb-875a-397d39d0ff1a.png) ended up having too little gameplay time, so a [second sketch](https://user-images.githubusercontent.com/15057519/121359824-7c22cf00-c8f9-11eb-90cc-e2cfe4466221.png) was made to extend the level and challenge the player a bit more. A few fine-tuning examples are documented [here](https://github.com/jtmeneses707/ECS189L-Final/blob/6a3563c280791cdbcd5b29f0ea2d2ad55e96cf83/LevelTuningExamples.md).
- *Fire Pits* - While designing the level, coming up with different block arrangements felt repetitive, so I came up with a mechanic based on environmental damage and needing to circumvent it using the dashing ability. This seemed like a good idea as it makes the game more skill-based and provides the player with an additional challenge. The implementation can be found [here](https://github.com/jtmeneses707/ECS189L-Final/blob/d445f367f9d7a0ef054fa07e075edab0aba263f7/189L%20Final/Assets/Scripts/Player/PlayerController.cs#L81).
- *Sky Gradient* - To improve the visuals of the world, I added a gradient sky based on the color palette of the environment, which I did creating a [pixel palette](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Resources/Backgrounds/4PixelSkyPalette.png). This can be found in the [scene](https://github.com/jtmeneses707/ECS189L-Final/blob/d445f367f9d7a0ef054fa07e075edab0aba263f7/189L%20Final/Assets/Scenes/Gameplay.unity) of the game.

### Johnson Le ###
- *Slime Form* - I implemented the logic of the player transforming to the slime and transforming back to its original form, The player transforms into the slime after taking three hits. However, once in slime form they can transform back into their original form once they land two of their attacks, gaining all their health back in the process. To add to the visuals of the transformation I created an animated object (essentially a brief smoke effect) that is attached to the player. This would appear whenever they transformed and then disappears after a short period of time.
- *Damage Indication* - To add to the game feel of the game, I made it so that the player's and enemies briefly shined white whenever they took damage. This approach was inspired by games such as MegaMan and implemented by switching out the material of the game object whenever they took damage, and then reverting back to its original material after a brief delay.
- *Level Implementation* - Following Jerrie's level design, I created a tile map so that could easily place all the platforms. I then created the level which was then finetuned by Jerrie after gameplay testing.

### Joshua-Troy Meneses ###

- *Hitboxes/Hurtboxes Fine Tuning* - I create hitboxes and hurtboxes for the players and enemies and edited their positioning and sizes to match the animations. 
- *Animation Events* - I helped with the damage logic for players and enemies by using animation events to check during which frame a hitbox/attack should be active. 
- *Camera Logic* - I added the camera logic/setup the scene with a specific distance between the camera and scene. This included a parallax scrolling background to add to game feel/immersiveness. This affected the FOV/how much of the scene can be scene during gameplay, further adding to game feel. I also tested the different camera types and found that a push box more to the right of the screen would help create a sense of urgency during gameplay. 
- *Reworking dash script* - I rebuilt the entire dash script so that it would work smoother with the animation. 

### Tommy Saechao ###
- *Enemy Animation State Transitions* - I created state transitions in the Animator tool for enemies to fluidly react to the player based off of certain game conditions. This gives a more dynamic behavior for the enemies making the enemies behave more naturally. In addition to the state transitions, I implemented scripts in the existing state to further support the simplification of the game logic making the software design of the game more maintainable and reusable for further development.
- *Enemy Mechanics (Physics/Movement)* - Since we had a missing role, I took part in the enemy portion of implementing the enemy mechanics in the game. I created an abstract controller to be used as a base for the types of enemies in the game. I also used a single file to hold constant values for enemy stats in the game. This robust design choice makes it easier to maintain and expand the code because we are able to build multiple different types of enemies off a single controller and adjust the physics attributes and stats at the same time. Taking a part of this unprescribed role taught me how to bring enemy game mechanics to life. 
- *Environment Physics and Collider Adjustments* - As I worked on my Game Logic and Game Feel role, many of the game logic work for the AI depended on the mechanics and physics of the enemies to be be completed. I took upon being able to learn and contribute to the adjustments of hitboxes of the enemy and tuning the colliders to make the game feel more accurate. Along with that, one of the most difficult obstacles that I came across was handling collisions among the scene and different components in the game. I overcame this obstacle through great amounts of research along with trial and errors in order to fully get the game feel right with the scripts that supplemented the collider hitboxes.
- *Enemy Testing* - While implementing the enemy logic, I spent a considerable amount of tiem adjusting and testing the attributes associated with the enemy controller in order to get the game feel with the enemy just right.

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface - (Jerrie Kraus-Liang)

The user interface is designed based on the core game logic and any information we believe is necessary for the player to have when challenging the Demon King. There are four scenes, three of which are for purposes of the user interface only. Any buttons or interactables in the UI have simple shadows when hovered or clicked to provide feedback to the player, letting them know a button is interactable or that they have successfully clicked the button. All user interfaces were tested for any major discrepancies between differing monitor specs and should display properly for all aspect ratios and resolutions.

![image](https://user-images.githubusercontent.com/15057519/121341896-b9319600-c8e6-11eb-9904-3bc270f82e10.png)

- *Start Screen UI* - The scene that first appears when the player runs the game. Can go directly into the gameplay, check the controls, or quit the game. [Image of UI](https://user-images.githubusercontent.com/15057519/121342716-88059580-c8e7-11eb-9fd5-898a5781be8d.png).
- *Controls Scene UI* - The scene that appears when a player wants to check the controls of the game. Tips are also included so the player knows all of the functionalities of the game logic beforehand, something which seemed to be necessary after gameplay testing. Can go back to the main menu or quit the game. [Image of UI](https://user-images.githubusercontent.com/15057519/121343293-2265d900-c8e8-11eb-843c-b563a0d7d7f9.png).
- *Credits Scene UI* - Credits our groupmates for their hard work in their respective roles! Can go back to the main menu or quit the game. [Image of UI](https://user-images.githubusercontent.com/15057519/121343458-504b1d80-c8e8-11eb-9737-2085e39cab92.png).
- *Gameplay UI* - See below.

### Gameplay UI ###
The Gameplay UI is a bit more interesting as it has many pop-up menus for the player to interact with.
![image](https://user-images.githubusercontent.com/15057519/121344105-f9921380-c8e8-11eb-87bd-4dab7b37c7d3.png)
- *Heart Bar* - The Heart Bar UI is also anchored to the bottom right of the screen to adjust to any resolution, as well as communicate with the player how many lives they have left. Upon taking damage, the player will lose hearts. Health is checked on every update and the UI is updated accordingly [here](https://github.com/jtmeneses707/ECS189L-Final/blob/d445f367f9d7a0ef054fa07e075edab0aba263f7/189L%20Final/Assets/Scripts/Player/HealthController.cs#L38).
- *Controls Pop-up Menu* - After gameplay testing, many players did not learn that they could double jump, phase through fire pits, or down smash by themselves. We added a control scene and a control UI so players don't need to figure out the controls through trial and error, and can always refer back to the controls by pausing the game and pulling up the controls pop-up menu.
- *Three Pop-up Menus* - In addition to the controls pop-up menu, there are three additional pop-up menus in our Gameplay scene, the [Victory Menu](https://user-images.githubusercontent.com/15057519/121344920-e0d62d80-c8e9-11eb-8ab9-cc53bd920043.png), the [Pause Menu](https://user-images.githubusercontent.com/15057519/121345022-fc413880-c8e9-11eb-8af2-fd5d19a0ad25.png), and the [Defeat Menu](https://user-images.githubusercontent.com/15057519/121345051-0400dd00-c8ea-11eb-8e80-20df11a52106.png). Players can always pause the game by pressing their escape key, and victory and defeat screens appear according to the game logic. All scripts for these menus can be found [here](https://github.com/jtmeneses707/ECS189L-Final/tree/main/189L%20Final/Assets/Scripts/UI).

## Movement/Physics (Johnson)

**Player Movement/Physics**

Since our game is a 2D action platformer, we followed the basic movement scheme of moving left, right, and jumping. These were implemented using the general physics system within Unity by changing the velocity of the player. To add more obstacle and platforming potential we gave the player the ability to double jump. This was done using a ground check 2D box collider positioned at the feet of the player. Along with this we implemented the dash ability so that the player could go through enemies/ obstacles for more gameplay variation. This dash was implemented using a transform position in update to give it a smooth visual. As for the rest of the player's abilities (melee, shoot, down smash), they were implemented using various child objects (with their own colliders and unique positions) that are attached to the player. The melee (positioned in front of the player) uses an overlap circle to detect all the enemies caught within its range and deal damage accordingly. The down smash does the same thing but instead uses a general overlap collider (placed below the player), to better represent range of the attack's shape. The shoot creates a projectile prefab at a transform placed at the player's hand. This projectile prefab has its own [script](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Audio/ProjectileController.cs) that controls its speed and enemy detection. To always keep these attacks' transforms in the correct position (relative to the player), we used a [IsFacingRight](https://github.com/jtmeneses707/ECS189L-Final/blob/0be3d083f41d95e88a517c3c06da5ba1c717862b/189L%20Final/Assets/Scripts/Player/PlayerController.cs#L54) boolean. With this we rotated the entire player gameobject, which also rotated it's children whenever the player turned around.

**General Physics Adjustment**

- We modified the colliders of the tile platform so that the top surface would be a little smaller. This was done so that it looked like the player was actually walking inside the path of the game visuals, instead of just being on top. 
- We also noted that the player could get stuck on the sides of walls and added a frictionless material to the player's collider so that they would just fall straight down. 
- The colliders for enemies attack hit boxes were removed when they weren't attacking, so that the player's projectile could hit the enemies' actual body hitbox.

## Animation and Visuals (Joshua-Troy)

**List your assets including their sources and licenses.**
We used many free assets hosted on itch.io. 
Many of these assets such as both of the main player's forms, the boss, and the environment are using [hugueslaborde's](https://hugues-laborde.itch.io/) sprite art.
The parallax mountains used in the background are from [anismuz](https://ansimuz.itch.io/mountain-dusk-parallax-background).
The skeleton enemy sprites are created by [Jesse Munguia](https://jesse-m.itch.io/skeleton-pack)

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**
***Assets***
We wanted our game to have a darker, retro style feel to it, creating a game inspired by the dark muted colors of Limbo, and the gothic/fantasy elements from games like Castelvania.  The colors for all of our assets are dark and muted, consisting of mainly shades for black, grey, or deep purples. The game world has a background consisting of cemetery, with gravestones piled high and an eerie mountainside set in the background, further enhancing the fantasy-horror game feel. Moreover, use of props like dilapidated churches or old trees helped to make the level feel less empty. I also took the liberty of editing some sprites, such as adding in lightning during an attack animation to create a sense great power during the wind up phase. In terms of graphic design, I made sure to include only sprites that had the same bit style. For example, some potential sprites were much too detailed, and ended up looking out of place with the rest of the assets.

***Animation*** 
I created all animations for the props (except for the water, thanks Johnson for the help!), player forms, and enemies. Some notable animation work includes messing with frame times and the spacing between key frames, especially with boss attacks. Animations at first were too fluid, as each key frame was spaced equally apart. Editing frame times and spacing lead to changing how some boss attacks feel, such as having a longer time between the start of an attack and the active attack frame to create a sense of power during the windup of the attack.  

## Input (Johnson)

**Default Configuration (as seen in the control menu of the game):**

![image](https://user-images.githubusercontent.com/50163129/121334293-6350f400-c8ce-11eb-8c1b-2f4360c8ef9c.png)

**Platform and InputStyle**

Our Project supports Unity Game version 2021.1.0f1 for MAC and Windows platforms. The main input style chosen was keyboard and mouse. However, only a keyboard is needed to be able to use all inputs as seen above.

**Implementation**

Following the command pattern exercise, we made an IPlayerCommand interface for executing each command. Meanwhile, a PlayerController class script was used to manage all the input for the commands that the player could use. These commands include: MovePlayerLeft, MovePlayerRight, MovePlayerUp, PlayerAbilityDash, PlayerAbilityMelee, PlayerAbilityShoot, PlayerAbilityDownSmash, all of which are executed using the inputs shown above (in the Default Configuration). I implemented the logic and physics for these commands and timed them with Joshua's animations to give off the overall feel of the player movement/ abilities.

[MovePlayerLeft](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Player/MovePlayerLeft.cs) - Moves the player left when given a negative x velocity.

[MovePlayerRight](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Player/MovePlayerRight.cs)- Moves the player Right when given a positive x velocity.

[MovePlayerUp](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Player/MovePlayerUp.cs) - Moves the player up (lets them Jump). There is also a double jump if the input is given twice.

[PlayerAbilityDash](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Player/PlayerAbilityDash.cs) - The player dashes in the direction that they are facing, dodging all enemies/ obstacles in their way.

[PlayerAbilityMelee](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Player/PlayerAbilityMelee.cs) - The player swings their fist, damaging all enemies caught in its range. This ability does a medium amount of damage.

[PlayerAbilityShoot](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Player/PlayerAbilityShoot.cs) - The player shoots a projectile towards the direction that it is facing. This move does the least amount of damage to encourage more aggressive gameplay with the other moves.

[PlaterAbilityDownSmash](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Player/PlayerAbilityDownSmash.cs) - The player does a powerful explosive attack underneath it, hurting all enemies in range. To balance this move, the player has to stand still during the entire attack which makes theme susceptible to enemy damage if timed improperly.

## Game Logic (Tommy Saechao)

**Game States and Design Patterns**

For the enemy states, I implemented the base states of being able to idle, move towards the player, and attack the player. When implementing the skeleton, the state logic was simple, as there are not many transitions to select from. However, for the boss, the states became extremely intricate due to the amount of different abilities and behaviors that the boss logic had. To make an intricate problem more simple, I used the state pattern in order to handle the transitioning of the multiple different types of boss abilities. 

**Implementing Enemy Abilities**

For the enemy abilities, the state pattern made it very simple to select between the choice of abiltiies at random. For the skeleton, only an melee attack is implemented, however for the boss, [the following abilities are implemented](https://github.com/jtmeneses707/ECS189L-Final/blob/aa36bec4e2641e196900e0da98389cb2968c2b23/189L%20Final/Assets/Scripts/Enemy/DemonKing/Boss_Attack.cs#L20):


Slash Attack - Swings the sword at player slashing him

Stab Attack - Stabs the player with the sword

Single Stab - A faster version of the stab attack

Slash Stab Combo - Combination of both slashing and stabbing the player

Double Slash Combo - Combination of slashing the player twice

Dash - Dashes towards the player


**More Design Patterns**

I used the factory and command pattern as a combination in order to make integration of enemy movement as a controller more manageable and simple. This improves the ease of refactoring, modifying, and building on top of existing code without having to worry about breaking enemy features in the game. 

**Game Data**

I managed all of the data for the enemies by implementing the attributes of the data inside each controller. I took into account of making the code as clean as possible for maintenance by creating a global constants file holding attributes such as the enemy health, visibility radius, attack radius, cooldowns of abilities, movement and movement speeds. This allows for easy refactoring in further processes as these constants are often used and reassigned in the controller. It saves the developer from having to dig through the entire source code of the scripts just to make a single adjustment to an enemy attribute such as the maximum health.



# Sub-Roles

## Audio - (Johnson Le)

**Sound Style**

Following the dark asthetics of our game's visuals and story, the main theme was chosen to convey a constant state of dread and pressure. There is also a win theme and a lose theme. The win theme fittingly conveys a happy and uplifting ending, as you have just slain the evil Demon King that killed your people. Meanwhile, the lose theme is quite sad and dejected, which encourages the player to hit the play again button and have another attempt at the game. Finally, there is a final boss theme. This one is quite upbeat and epic, since we wanted the final part of the game to be as intense as possible.

Furthermore, throughout the game, there are alot of audio cues to give it more depth. I took some inspiration from popular mainstream games. For example, the walking sound is very similar to that of walking on gravel in Minecraft. Another example would be how the damage sound for the player is very similar to alot of 2D action platformers such as Hollow Knight. However, there were a lot of sound effects such as the water and fire SFX, that were chosen because they gave the player a distinct audio cue for an interaction that took place. These sounds were chosen because they were vividly realistic which makes the player take notice of how dangerous the environment can be. This was done in the hopes that they would be encouraged to avoid these obstacles as well as improve their gameplay.

**Implementation**

All the audio that was implemented in the game was attached to a AudioManager prefab in each scene of our game. This prefab held an [AudioManager.cs script](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Audio/AudioManager.cs) that could play and stop all the audio that was attached to it, which includes all the [themes](https://github.com/jtmeneses707/ECS189L-Final/tree/main/189L%20Final/Assets/Resources/Music) and [sound effects](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Audio/Sound.cs) within the game. Along with this is a Sound Script used to allow us to change various properties of the audio while testing. These properties included: volume, pitch, and the ability to loop (which was very handy for playing themes). Lastly, there was a [SwitchMusicTrigger.cs](https://github.com/jtmeneses707/ECS189L-Final/blob/main/189L%20Final/Assets/Scripts/Audio/SwitchMusicTrigger.cs) file. This was used to change the main theme to the epic boss music, once the player had entered the boss' area.

**Assets:**

* Various License Free Sound Effects from: [Zapsplat](https://www.zapsplat.com/sound-effect-categories/)
* Unity Store Licensing: [FootSteps](https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879), [Main Theme](https://assetstore.unity.com/packages/audio/ambient/platformer-music-pack-lite-178337), [Win Theme](https://assetstore.unity.com/packages/audio/ambient/platformer-music-pack-lite-178337), [Lose Theme](https://assetstore.unity.com/packages/audio/ambient/platformer-music-pack-lite-178337), [Boss Theme](https://assetstore.unity.com/packages/audio/music/electronic/dark-boss-fight-side-scroller-background-78149)

**References:** 

* [Audio Manager Tutorial](https://www.youtube.com/watch?v=6OT43pvUyfY), 
* [Switch Music Tracks](https://www.youtube.com/watch?v=XoH8Qyqje1g)

## Gameplay Testing - (Jerrie Kraus-Liang)

Due to the lack of time left, the gameplay testing was conducted with two passes of play with the development team, followed by a group of willing friends to act as playtesters. With my main role being User Interface, I tried to identify any UI/UX problems early on before asking others to review and critique the game. One thing I kept in mind from class readings was how the UI was part of the gameplay experience, and is one of the key ways that the player interacts with the game. Originally, I had placed the hearts at the top left of the screen, but when playing and experiencing the game myself, I realized how awkward it was to have the player flick their eyes toward the top left of their screen in order to check how many lives they had left.

In the playtesting phase, some gameplay testing was done asynchronously, with people submitting a thoughtful review, while others played the game more casually and screenshared their gameplay, voicing their thoughts as they came. Some open-ended questions were asked to help develop a general theme of what should be improved in the next iteration of the game. 

The full gameplay results have been formatted in Markdown and can be found [here](https://github.com/jtmeneses707/ECS189L-Final/blob/0617f46a998cca9920d101acf5febe4edada251e/GameplayTestingResults.md).

**Key Findings:**
- Players were typically confused about what the controls were, so we should implement a UI with the controls indicated.
- Reduce the movement speed of the player to improve the mechanics and game feel.
- Increase the enemy aggro range and fix the floating/teleportation issues with the enemy AI.
- Add a cooldown (or increase the cooldown) on the dash, as it is overpowering the rest of the mechanics and dissuading players from engaging in any combat during the platforming.
- Consider adjusting or removing the moon animation - a few people thought the moon was actually bugged rather than the animation being a stylistic choice.
- Might be a bit too complex to figure out in time, but consider buffing the down smash. This could be done by increasing the range of damage, increasing the cast speed, or allowing the player to cast down smash while in the air.

## Narrative Design - (Jerrie Kraus-Liang)

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

In the early process of the game, our team brainstormed together looking at various characters and environmental designs, waiting to see what spoke out to us, keeping in mind the optional theme of "Power Down". After we found the sprites of Urumir's slime form and strong form, we thought it'd be cool to create a gloomy feeling game featuring a strong protagonist who powers down when injured and loses his strength, and crafted a narrative based upon this idea.

Originally, we had planned on having multiple levels and allowing Urumir to unlock the resulting abilities, acting as a parallel to Urumir's adventures and explorations in this fantasy world. However, due to the unexpected drop of a teammate, we needed to scale back our gameplay system, and so the system revolves around the time that Urumir ventures back home and finds his home destroyed.

**Narrative Presentations:**
- *Character Forms* - The ability to transform is clearly represented in the assets, as the weak form is a slime, and the strong form is neither human nor beast, representing what has become of Urumir after absorbing his enemies' abilities during his adventure.
- *Props* - Props such as graves and crosses represent Urumir's fallen loved ones, to represent the devastation and ruin of the land.
- *Gameplay* - In Urumir's strong form, he is able to use new abilities he gained from absorbing his enemies' abilities during his adventure, such as the dashing, the down smash, and the ranged attack.
*Gameplay System* - The platforming mechanic of this game is supposed to be somewhat challenging in order to represent the physical destruction to the land caused by the Demon King, as Urumir faces this as a legitimate obstacle when making his way to the Demon King.
- *Boss Battle* - The boss battle directly correlates with Urumir's face-off against the Demon King in order to exact vegenance.


## Press Kit and Trailer (Joshua-Troy)

**Include links to your presskit materials and trailer.**
I created our press kit using static html with css. I did not secure hosting for the files, and instead went with using htmlpreview.github.io to render our static files. There were some unforseen drawbacks with this, such as how long it takes for the static pages to load the linked files like css files. This results in a somewhat ugly webpage as it loads, but styles are eventually applied. With more time, I would make a website that is friendlier to screens smaller than 1920x1080, and include a mobile view. 
[Press Kit and Trailer](https://htmlpreview.github.io/?https://github.com/jtmeneses707/ECS189L-Final/blob/main/Press%20Kit/index.html)

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

***Trailer***
I watched a quick and short YouTube [video](https://www.youtube.com/watch?v=KRvEFwHXm8s) on how to create game trailers. One of the methods was called "Music Video Montage". The goal of this method was to create a quick and short video that would highlight fun aspects of our game while ramping with the intensity of the music, creating a trailer that is engaging for the viewers. I first start with basic visuals like the starting screen or simple walking, then gradually progress to more and more hectic gameplay, such as platforming and attacking multiple enemies. The trailer culminates into showing a preview of the fight with the final boss, saving the most epic part of the game for last. 

***Screenshots***
I chose a 4 screenshots that varied with intensity with each of them. This follows along with the main goal for the trailer.




## Game Feel (Tommy Saechao)

In order to improve the game feel, I made modifications based on the congruency of the player and enemy mechanics. If the enemy chases the player at too fast of a speed or had too muc health, it would make the game feel as if the player was less powerful than the weakest enemy in the game. This would discourage the player from playing the game as it becomes too difficult. While testing the game, I made adjustments to the attributes of the enemy to make the game seem difficult, but beatable. This creates a more rewarding system of playing the game and getting closer to the final boss. Along with that, I tested the player movements on how it interacts with the game obstacles and made suggestions for what would improve the feel of the game. The suggestion that stood out the most was the player's movement speed. It was very difficult to navigate and move through obstacles in the scene as the player would move too fast and miss a platform causing the player to often fall to their deaths. 


Apart from the enemy and player mechanics, I had to make decisions with how the enemy and player would interact when they collide with each other. One difficult debate was whether to allow the enemy and player to push each other around as they collide with one another, or to allow them to simply phase through. After several amounts of testing, it was made that the collision between enemies and players could be overabused as the player could simply push the boss off of the edge of the map and vice-versa. Therefore, I made the implementation for the player to be able to phase through the enemy, but not the enemy being able to phase through the player. Additionally, after an abilty collision with the enemy or the player (depending on who got hit), sound and animation was played to make the player feel like they are actually getting hit or taking damage and vice-versa with hitting the enemy.
