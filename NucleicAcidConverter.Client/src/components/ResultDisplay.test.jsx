import { describe, expect, test } from "vitest";
import ResultDisplay from "./ResultDisplay";
import { render, screen } from "@testing-library/react";

describe("ResultDisplay", () => {

  test("displays correct result", () => {
  
    const props = {
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
    const resultElement = screen.getByTestId("result-display");
    
    expect(resultElement.textContent).toBe("Asparagine - Lysine");
  });
});
