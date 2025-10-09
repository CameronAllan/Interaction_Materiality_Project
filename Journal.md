# Journal

## Friday, Oct 3rd, 2025

### Design

Initial commit

Ok, so the goal here is to create a small digital toy that will allow users to customize simple digital interactions. E.g. add SFX, haptics, simple animations to a button to make it "feel" good.<br>

I'll probably start by roughing out the basic button functionality, then building onto it.
Right now I'm kind of envisioning like a video-editing timeline that will drop down and allow you to place effects on it?

### Dev

Intial commit

Unity had a security issue with every release they've ever put out, apparently. Spent the morning updating all my installs and I'm going to have to crunch out updated builds for everything I've released...


## Thursday, Oct 9th, 2025


### Design

Alright, so I've roughed out the basic interaction and a system to handle customizing effects. Leaning towards just using Prefabs and Instantiating/Destroying them as they get added or removed for now. Not the most efficient, but gets this trainwreck rolling.
There's gonna be a lot of distinct little component that'll get mixed and matched, so I do think that it's maybe a good choice if I'm smart about it.

### Dev

World's most convoluted button is in - ended up going for an Effect class that lives on a gameobject and then gets daisy-chained together by a parent object that (in the future) will specify what kind of Effects it'll take (SFX, Anim, etc.).
The button starts with default, uneditable effects that just move the pressable bit up and down on mouse events, then I'm thinking that I can just instantiate prefabs for new "effect tracks" like in a video editing software?


