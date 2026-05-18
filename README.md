# windows

Repo of Windows applications and POCs.

## RKC modular WinUI host baseline

This repository now includes a modular Windows solution scaffold for **RKC Windows Host App** (`RKC.Win.HostApp`) with support for:

- WinUI 3 host app project (`/home/runner/work/windows/windows/src/Host/RKC.Win.HostApp`)
- WAP/MSIX packaging project (`/home/runner/work/windows/windows/src/Host/RKC.Win.HostApp.Package`)
- Background worker service project (`/home/runner/work/windows/windows/src/Host/RKC.Win.BackgroundService`)
- Reusable common library and UI composition projects
- Module-first architecture for `Nestize` (society management) and `Contacts`

## Project organization

- `RKC.<ModuleName>.Entity`: domain entities and enums
- `RKC.<ModuleName>.Contracts`: contracts/interfaces shared across modules
- `RKC.<ModuleName>.Lib`: business logic/services
- `RKC.<ModuleName>.ViewModel`: view models
- `RKC.<ModuleName>.View`: composable view-layer contracts/components

### Added modules

- `Nestize`: society management (members, owner/tenant model, association office bearers)
- `Contacts`: reusable contact directory and contact-visibility policy

## Business rule implemented

Contact visibility enforces reciprocity:

- If a member hides their phone number, they cannot see others' phone numbers.
- A member can only view another member's phone number when both have opted to share.

## Tests

Focused tests for the visibility rules are in:

- `/home/runner/work/windows/windows/tests/RKC.Nestize.Lib.Tests/Society/SocietyContactVisibilityTests.cs`
