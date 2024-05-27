// Calculator.js
import React, { useState } from "react";
import Navbar from "./Navbar";
const Calculator = () => {
  const [num1, setNum1] = useState("");
  const [num2, setNum2] = useState("");
  const [operator, setOperator] = useState("add");
  const [result, setResult] = useState("");

  const handleCompute = () => {
    let computedResult;
    switch (operator) {
      case "add":
        computedResult = parseFloat(num1) + parseFloat(num2);
        break;
      case "subtract":
        computedResult = parseFloat(num1) - parseFloat(num2);
        break;
      case "multiply":
        computedResult = parseFloat(num1) * parseFloat(num2);
        break;
      default:
        computedResult = "";
    }
    setResult(computedResult);
  };

  return (
    <div>
      {<Navbar />}
      <div className="calculator">
      <h1>Calculator</h1>
      <form onSubmit={(e) => e.preventDefault()}>
        <input
          type="number"
          value={num1}
          onChange={(e) => setNum1(e.target.value)}
        />
        <select value={operator} onChange={(e) => setOperator(e.target.value)}>
          <option value="add">Add</option>
          <option value="subtract">Subtract</option>
          <option value="multiply">Multiply</option>
        </select>
        <input
          type="number"
          value={num2}
          onChange={(e) => setNum2(e.target.value)}
        />
        <button onClick={handleCompute}>Compute</button>
      </form>
      <p>Result: {result}</p>
    </div>
    </div>
  );
};

export default Calculator;
