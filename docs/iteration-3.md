# Iteration 3 Report

## Goal

The goal of this iteration was to improve software quality, testability and fault tolerance of the Banking System project.

---

## Refactoring Performed

The following improvements were made before expanding the test suite:

- separated persistence responsibilities;
- reduced hidden dependencies;
- improved testability through interfaces;
- prepared services for integration testing.

---

## Unit Testing

Unit tests cover:

- domain invariants;
- deposit operations;
- withdrawal operations;
- transfer operations;
- factory pattern;
- query services;
- negative scenarios.

Total unit tests: 15+

---

## Integration Testing

Integration tests cover:

- JSON persistence;
- state restoration;
- save/load cycle;
- corrupted JSON handling;
- missing file handling;
- operations after reload.

Total integration tests: 8+

---

## Fault Handling

Verified scenarios:

- invalid deposit amount;
- invalid withdrawal amount;
- insufficient funds;
- transfer to the same account;
- missing data file;
- corrupted JSON file.

---

## Quality Gate

CI pipeline validates:

- restore;
- build;
- test execution;
- coverage generation.

Any failed test causes pipeline failure.

---

## Coverage

Coverage is generated using Coverlet.

Coverage report is available through local execution and CI pipeline.

---

## Remaining Risks

- large data set performance has not been measured;
- concurrent access is not implemented;
- persistence is file-based and not transactional.

---

## Preparation for Lab 37

The next iteration will focus on:

- release preparation;
- final documentation;
- user guide;
- developer guide;
- demo scenario;
- final report.
