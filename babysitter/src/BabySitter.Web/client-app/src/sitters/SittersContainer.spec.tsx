import { createMockStore, mountWithStore } from "../../testing";
import { SittersContainer } from "./SittersContainer";
import { loadSitters } from "./actions";

it("should get sitters", () => {
  const store = createMockStore();
  mountWithStore(SittersContainer, store);
  expect(store.getActions()).toContainEqual(loadSitters());
});

it("should show list of sitters", () => {
  const store = createMockStore({
    sitters: {
      [5]: { id: 5, firstName: "one" },
      [2]: { id: 2, firstName: "two" },
      [1]: { id: 1, firstName: "three" }
    }
  });
  const container = mountWithStore(SittersContainer, store);
  expect(container.text()).toContain("one");
  expect(container.text()).toContain("two");
  expect(container.text()).toContain("three");
});