import { describe, expect, test } from "vitest";
import ResultDisplay from "./ResultDisplay";
import { render, screen } from "@testing-library/react";

describe("ResultDisplay", () => {

  test("displays correct result", () => {
  
    let props = {
      translationResult: [
        {
          name: "Asparagine"
        },
        {
          name: "Lysine"
        }
      ],
      displayedProperty: "name",
      loading: false
    };
  
    render(<ResultDisplay {...props} />);
    screen.debug();
    const resultElement = screen.getByTestId("result-display");
    expect(resultElement.textContent).toBe("Asparagine - Lysine");
  });
});
