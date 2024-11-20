# Guestia coding task - Mike Randall

Initial commit is a quick way to directly return the results.

A question about ordering of the guests. How should surnames like `de Santos` or `McAdams` be treated? should `de Santos` start with a `d` or an `S`? and similar with `McAdams` should it start with `M` or `A`?

Update separates out services and interfaces to retrieve and format the data, and corrects the query to only return unregistered guests.

Given more time on the task I would have liked to inject the context and load settings via configuration, ideally via a startup type class.
I would also have liked to have created integration tests around the data query, and unit tests around the GuestFormatter.
