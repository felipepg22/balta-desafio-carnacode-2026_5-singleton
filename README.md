![CR-5](https://github.com/user-attachments/assets/e212d619-61a8-4e74-8b15-283b374c9d3f)

## 🥁 CarnaCode 2026 - Challenge 05 - Singleton

Hi, I am Felipe Parizzi Galli, and this is the space where I share my learning journey during the **CarnaCode 2026** challenge, hosted by [balta.io](https://balta.io). 👻

Here you will find projects, exercises, and code that I am building throughout the challenge. The goal is to get hands-on, test ideas, and track my growth in tech.

### About this challenge
In the **Singleton** challenge, I had to solve a real-world problem by implementing the corresponding **Design Pattern**.
During this process, I learned:
* ✅ Software Best Practices
* ✅ Clean Code
* ✅ SOLID
* ✅ Design Patterns

## Problem
An application needs to load database, API, and cache settings only once and share them across all components. The current code allows multiple instances, causing inconsistencies and wasting resources.

## About CarnaCode 2026
The **CarnaCode 2026** challenge consists of implementing all 23 design patterns in real-world scenarios. Throughout the 23 challenges in this journey, participants practice identifying non-scalable code and solving problems using industry-standard patterns.

### eBook - Design Patterns Fundamentals
My main source of knowledge during this challenge was the free eBook [Design Patterns Fundamentals](https://lp.balta.io/ebook-fundamentos-design-patterns).

## What was implemented to apply Singleton
- The `ConfigurationManager` constructor was made `private` to prevent direct instantiation from outside the class.
- A static field (`_instance`) was added to hold the single shared instance.
- A static lock object (`_lock`) plus double-check locking was implemented in `Instance` to ensure thread-safe lazy initialization.
- Configuration loading was centralized in `LoadSettings()` and executed only once, when the singleton is first created.
- Application services (`DatabaseService`, `ApiService`, `CacheService`, and `LoggingService`) now access configuration through `ConfigurationManager.Instance`, ensuring all of them use the same shared state.
- Runtime updates (for example, `UpdateSetting("LogLevel", "Debug")`) affect the same singleton instance used by all components.
