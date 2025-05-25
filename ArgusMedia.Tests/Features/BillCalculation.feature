Feature: Bill Calculation
  Calculates correct bill with pricing rules, discounts and service charges.

Background:
    Given the service is started

Scenario: A group of 4 people order full meals
    Given the following group order at 12:30:
      | Starters | Mains | Drinks |
      | 1        | 1     | 1      |
      | 1        | 1     | 1      |
      | 1        | 1     | 1      |
      | 1        | 1     | 1      |
    Then the total amount should be £58.40, service charge should be £4.40 and discount should be £0.00

Scenario: Group expands and orders at different times with applied drink discount
    Given the following group order at 18:30:
      | Starters | Mains | Drinks |
      | 1        | 1     | 1      |
      | 0        | 1     | 1      |
    When the following group order at 20:00:
      | Starters | Mains | Drinks |
      | 0        | 1     | 1      |
      | 0        | 1     | 1      |
    Then the total amount should be £43.70, service charge should be £3.20 and discount should be £1.50

Scenario: Order is updated after cancellation
    Given the following group order at 20:30:
      | Starters | Mains | Drinks |
      | 1        | 1     | 1      |
      | 1        | 1     | 1      |
      | 1        | 1     | 1      |
      | 1        | 1     | 1      |
    Then the total amount should be £55.40, service charge should be £4.40 and discount should be £3.00
    When one client cancels their order
    Then the total amount should be £41.55, service charge should be £3.30 and discount should be £2.25 