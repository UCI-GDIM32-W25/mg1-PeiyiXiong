
# HW1
## Devlog
### Part 1
Peiyi Xiong, she/her
### Part 2
My MG1 game plan has four main things: Seeds, Main camera, Player, and UI/text. I used code and Unity to make all of them work, and they match specific parts of my project clearly.

First, the **Player** object:
It has `Position` and `Speed`. These are in the `Player` code file. `Position` uses `_playerTransform` to track where the player is. `Speed` uses `_speed` in the code to control movement speed. The player can do two things: move with WASD and plant seeds with Space. The `Update()` method in the `Player` code handles movement: it gets WASD input with `Input.GetAxisRaw()`, then uses `_playerTransform.Translate()` to move the player. When I let go of the key, the player stops right away. For planting seeds, `Update()` checks if I press Space, then calls the `PlantSeed()` method to plant.

Second, the **Seeds** object:
Seeds have `Position`. They spawn where the player is. The `PlantSeed()` method uses `_playerTransform.position` to get the player's spot, then uses `Instantiate()` to create a seed (from the `Plant` prefab in Unity) there. The seed's job is to "be planted." The `PlantSeed()` method first checks if there are seeds left (`_numSeedsLeft > 0`), then makes a seed object. The code has `_numSeedsLeft` and `_numSeedsPlanted` to track numbers for the UI.

Third, the **UI/text** object:
Its job is to show how many seeds are left and planted. This uses the `PlantCountUI` code file and its `UpdateSeeds()` method. In Unity, I made two text things: `PlantedText` and `RemainingText`, and linked them to the `PlantCountUI` code. After planting a seed, the `PlantSeed()` method sends the new seed numbers to `PlantCountUI` with `UpdateSeeds()`. Then the text updates to show the right numbers right away, just like my plan said.

Fourth, the **Main camera** object:
It’s the default camera in Unity. It shows the whole game—like the player, planted seeds, and the UI. I can see the player move and seeds grow because of it. It’s important for the game to work.

Finally, how these things work together:
 `Player -> Seed`: When I press Space, the `Update()` method sees it, and `PlantSeed()` makes a seed where the player is.
`Seed -> UI`: The `Player` code sends seed numbers to `PlantCountUI`, and the UI text changes to show the new numbers.
