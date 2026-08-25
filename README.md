# Clients monorepo

This repository keeps each client/package as a separate .NET project under its own folder.

Structure:

- `Clients.slnx` - solution entry point
- `RadioBrowser/` - package/client project
  - `RadioBrowser/RadioBrowser.csproj` - NuGet project
  - `RadioBrowser/CHANGELOG.md` - generated changelog for the package

Release flow:

- every PR should use a conventional commit scope matching the client name, for example `feat(radio-browser): ...`
- on merge to `master`, the release workflow reads the scope and creates a package release only for that project
- `release-please` manages automatic changelog creation and semantic versioning
- the workflow then packs and publishes the NuGet package to nuget.org

If you add another client, create a new folder under the repo root and register it in the release config. The pattern is reusable for all future packages.
