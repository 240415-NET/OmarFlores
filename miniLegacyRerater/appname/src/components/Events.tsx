
import * as React from 'react';

const Events = () => {

  // function to be called on a click event
  // function clickEventHandler(){
  const clickEventHandler = ()=> {
    console.log("just clicked the button")};

  return (
    <div>
      {/* <button type="button">Click Me</button> */}
      <button onClick={clickEventHandler}>ClickMe</button>
        <br></br>
        <text id='myText'>MyText</text>
        
    <h2>
        How to use TextField 
        Component in ReactJS?
    </h2>
    <input
        type='text'
        id="EnterYourName"
        placeholder='YourName'
        value="helloWorld"
        onChange={(e) => 
            e.target.value
            
        }
        />
    </div>
    );

};

export default Events;