# libsm64-unity-melonloader

Modification of [libsm64-unity](https://github.com/libsm64/libsm64-unity), intended for modding Unity games through [MelonLoader](https://melonwiki.xyz).

This template covers the adaption of libsm64-unity so that it can be used as a MelonLoader mod, however you must make some changes in order to adapt it to the game you want to mod.

* Create a new project in Visual Studio using the MelonLoader Mod template.
* Copy everything in this project into yours.
    * Be careful not to copy over the [assembly] lines in Core.cs. Make sure they remain unmodified in your project.

Don't forget to compile the libsm64 DLL itself as well. sm64.dll must be placed in the same directory as the game's exe.
