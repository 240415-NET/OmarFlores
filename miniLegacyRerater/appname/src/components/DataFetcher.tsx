// # Exercise 6 - useEffect
// ## Description
// This exercise will involve the creation of a component that uses the `useEffect` hook to make an API call when the component first loads. You will display the fetched data within the component.
// ## Approach
// 1. Create a new function React TSX Component called "DataFetcher".
// 2. The component should fetch data from an API when it first loads.
//     - You can use `Axios` or `Fetch`
// 3. Use the `useEffect` hook to perform the API call.
// 4. Use the `useState` hook to manage the fetched data and loading state.
// 5. Display the component on the web page using the `App.tsx`.
// 6. Ensure the component correctly displays the fetched data or a loading indicator while the data is being fetched.
// ## Hints
// - The component should be focused on demonstrating the use of the `useEffect` hook for making API calls.
// - You should use `useState` to manage the state of the fetched data and the loading state.
// - The component should be imported into your `App.tsx` and displayed like an HTML element.
// ```typescript
// // interface used to describe the shape of the api response
// interface Data {
//     name: string,
//     value: number
// }
// //state variable storing the state
// let [data, setData] = useState<Data | undefined>(undefined);
// // async function to get the data
// async function getData(){
//     let response = await axios.get('EXAMPLE URL');
//     setPokemon(response.data);
// }
// // useEffect to do the call when the component loads
// useEffect(() => {
//     getData();
// }, []);
// ```

import React, { useState } from 'react'

//We will leverage typescript's type system, and make sure that we get objects to render
//that conform to our specification of an item for our app
interface Policies {
  policyId: string;
}

//This is an additional interface contain the list of items that we will pass as a prop 
//from UserInfo to ItemList
// interface PoliciesProps {
//   PoliciesInfo: Policies[];
// }
// async function to get the data

// async function getData1(){
//     let response = a+b;
//     return response;
//     //setData(response);
//     //setPokemon(response.data);
//}
// // useEffect to do the call when the component loads
// useEffect(() => {
//     getData();
// }, []);

//ItemList receives an "argument", called a Prop in react, from it's parent UserInfo
//function PoliciesList({PoliciesInfo}: PoliciesProps) {
    function PoliciesList() {
         const [policies, setPolicies] = useState("string");
       
        
        async function getData(){
            let acc = "";
            let policies = fetch('http://localhost:5286/Groups?state=FL')
           .then(policies => policies.json())
           .then(data => acc = data[0]+","+data[1]+","+data[2])
           .then(data => {setPolicies(acc);console.log(data[0]);})
           .catch(error => console.error(error));
//           setPolicies(policies);
           
            //  return policies;
         }
        return (
            
    <div id='policies-container'>
        <p>----------------------- DataFetcherComponent ---------------------------</p>
        {/* <input type="text" value={"response here"} onChange={getData}/> */}
        <button onClick={getData}>{policies}</button>
        
      <ol id='policies-list'>
        {/* Here I will use the javascript array.map() method to render my line items based on the item list 
        that is passed in as a prop when this component is rendered. */}
        {/* Lists in react expect something from each item in the list - a key. Think of it as a primary key
        that react can use to refer to each item that we are going to dynamically render */}
        {/* {itemsFromUserInfo.map((individualItem)  => (
            <li key={individualItem.itemId}>
              {individualItem.category} - {individualItem.description} - {individualItem.originalCost}
            </li>
        ))} */}
      </ol>
    </div>
  )
}

export default PoliciesList

