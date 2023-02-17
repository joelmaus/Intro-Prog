# Test Doubles

Objects that are used during testing to replace other dependencies so that we can verify things.

## Dummies

Just place holders. We can't pass in a null, so we need to pass *something* in. Doesn't have anything to do with the test we are writing.

## Stubs

Are test doubles that have "canned" answers to questions. 

> If your Log method gets called with any arguments, throw an exception.

> If your calculate bonus gets called with 118M, 5000M, return 42

This is called "State based testing" because we can tell by looking at the state of the system under test to make sure our code behaved properly.


## Mocks

Record all uses of them in the system under test.

We can `Verify` that our SUT interacted properly with the dependency by calling verify.

## Fakes

Mostly used in acceptance testing or integration testing.
These are things like a test database or something.
