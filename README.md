# Demonstration of Bogus Data Generator

This is a demonstration of how to create a fake list of customer data.  Eventually I will add some tests to show how it works for creating sample data for mocking in unit tests.

Bogus is an open source NuGet package:
https://github.com/bchavez/Bogus

A simple and sane fake data generator for C#, F#, and VB.NET. Based on and ported from the famed faker.js.

# Feature Highlights
- When creating the Faker, as long seed the Randomizer with the same number, it will generate the same data every time which makes this great for unit testing.
- There are several types of "rules" that can be created to help guide the generator towards the type of data you need.
- There are several locales available so you can generate test data in different languages.