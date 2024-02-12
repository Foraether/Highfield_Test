import { useEffect, useState } from 'react';
import './App.css';
import Content from './Content';
import UserContent from './UserContent';

function App() {
    const [colours, setColours] = useState();
    const [users, setUsers] = useState();
    useEffect(() => {
        populateColourData();
        populateUserData();
    }, []);

    

    return (
        <div>
            <h1 id="tabelLabel">Highfield Test Answers</h1>
            <Content colours={colours} />
            <UserContent users={users } />
        </div>
    );
    
    async function populateColourData() {
        const response = await fetch('favouritecolour');
        const data = await response.json();
        setColours(data);
    }
    async function populateUserData() {
        const response = await fetch('userages');
        const data = await response.json();
        setUsers(data);
    }
}

export default App;