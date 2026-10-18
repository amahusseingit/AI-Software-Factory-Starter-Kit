# Coding Standards

## General
- prioritize readability
- use meaningful names
- avoid hidden coupling
- avoid duplication
- document public interfaces and important decisions

## Backend
- thin controllers
- business logic in services/use-cases
- repositories in infrastructure
- DTOs in contracts
- async methods
- validation required

## Angular
- service-only API calls
- no HTTP in components
- typed models
- clear UI states
- maintainable feature structure

## Flutter
- no HTTP in widgets
- model/service/provider/UI separation
- loading and error states required
- mounted checks after async operations when needed

## Testing
- no trivial tests
- include negative cases
- assertions must prove behavior
