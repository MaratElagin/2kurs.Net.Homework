import React, {useState} from 'react';

export function Counter() {
    let [count, setCount] = useState(0)

    let incrementCounter = function () {
        setCount(count + 1);
    }

    return (
        <div>
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <p aria-live="polite">Current count: <strong>{count}</strong></p>

            <button className="btn btn-primary" onClick={incrementCounter}>Increment</button>
        </div>
    );
}