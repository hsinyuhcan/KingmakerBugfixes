# KingmakerBugfixes
Community bugfixes for Pathfinder Kingmaker
## Compile
This project depends on [ModMaker](https://github.com/hsinyuhcan/KingmakerModMaker), you need both repos in the same folder, and a folder called `KingmakerLib` including the Dll files. The folder structure should look like:
```
Repos
│
├── KingmakerLib
│   ├── UnityModManager
│   │   ├── 0Harmony12.dll
│   │   └── UnityModManager.dll
│   └── *.dll
│
├── KingmakerModMaker
│   ├── ModMaker
│   │   └── ModMaker.shproj
│   └── ModMaker.sln
│
└── KingmakerBugfixes
    ├── KingmakerBugfixes
    │   └── Bugfixes.csproj
    └── KingmakerBugfixes.sln
```
