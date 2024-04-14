# Sneddsy Workspace

# Projects
## Krato
apps/krato-web  
apps/krato-web-e2e  
apps/krato-api  

### Description
Krato is a web app for recording strength workouts.

### Dependencies
- Node 20
- Yarn
- dotnet SDK 8
- [Optional] Nx ( or can use with `npx` )

### Working with Nx build tool for C#

Generate a new C# library project
```bash
npx nx generate @nx-dotnet/core:lib krato-api-domain --directory=apps/krato-api --language=C# --template=classlib
```

Restore NuGet packages
```bash
yarn run prepare
```

Build the Web API
```bash
npx nx build krato-api
```

Run the Web API
```bash
npx nx serve krato-api
```
