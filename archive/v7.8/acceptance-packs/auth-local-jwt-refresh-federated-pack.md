# Auth Local JWT Refresh Federated Acceptance Pack

Use this pack for systems with local authentication, JWT access tokens, refresh tokens, and optional federated sign-in.

## Local Authentication
- registration or user provisioning follows the project spec
- login succeeds with valid credentials
- invalid credentials are rejected securely
- password reset and change password behavior follow the spec

## Token Behavior
- access token is issued correctly
- refresh token rotation and revocation behave correctly when required
- expired access token handling is correct on web and mobile

## Federated Sign In
- federated sign-in providers are explicitly defined by the project spec
- first-time and returning-user behavior is consistent
- role, claim, and profile mapping are validated

## Authorization
- protected routes and APIs enforce access correctly
- role-based visibility and action permissions follow the spec
