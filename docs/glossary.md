# Glossary

This mod uses a glossary to standardize its content. Many conditions could be named differently, so a standard naming
convention is necessary.

## Overview

Conditions are split into three parts: prefix, verb and subject. Together, they form the following string:
`prefix_verb_subject`.

## Prefix

Prefixes define when the condition is checked. This allows to create a condition that *currently* checks for something,
or that checks if something has happened.

| Prefix | Definition                                         |
|--------|----------------------------------------------------|
| `is`   | Checking for something that is currently happening |
| `has`  | Checking for something that has happened           |

## Verb

Verbs define how the condition is checked. This allows to create a condition that checks one for X or for Y.

| Verb        | Definition                                              |
|-------------|---------------------------------------------------------|
| `completed` | Checks if the subject has been accomplished or finished |
| `deposited` | Checks if the subject has been permentally put down     |
| `killed`    | Checks if the subject has been permentally removed      |
| `defeated`  | Checks if the subject has been temporarily removed      |
| `obtained`  | Checks if the subject has been acquired                 |