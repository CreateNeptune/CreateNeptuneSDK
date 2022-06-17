# CreateNeptuneSDK

## How to Install
1. Open Unity Package Manager
2. Click the + in the top left.
3. Select "Add package from git URL..."
4. Paste the url ``https://github.com/wristshot0/CreateNeptuneSDK.git?path=/Packages/com.createneptune.sdk`` for the main sdk. For the addressables sdk paste, ``https://github.com/wristshot0/CreateNeptuneSDK.git?path=/Packages/com.createneptune.addressablessdk``.

## How to Update
In newer versions of Unity, there should be an Update button at the bottom left of the package manager when viewing the package. Otherwise, follow the same instructions as installation. You do not have to remove the old version and it will go faster if you don't.

## Troubleshooting
### Not logged in
You must log in since this is a private repo. To do so, use something like the [GitHub CLI](https://docs.github.com/en/get-started/getting-started-with-git/caching-your-github-credentials-in-git).

## Editing this Repo
Feel free to make all neccessary edits to this repo, just please notify the team when you do. The files to edit are in /Packages/com.createneptune.sdk

To publish the update, you must edit the version number in package.json and make an addition to changelog.md. Then push your changes to the repo.
