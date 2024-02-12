import PropTypes from "prop-types";

function UserContent({ users }) {
    if (users === undefined) {
        return <p><em>Loading...</em></p>
    }
    return (
        <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Age</th>
                    <th>Age plus 20</th>
                </tr>
            </thead>
            <tbody>
                {users.map(user =>
                    <tr key={user.id}>
                        <td>{user.firstName}</td>
                        <td>{user.lastName}</td>
                        <td>{user.age}</td>
                        <td>{user.ageInTwenty}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}
UserContent.propTypes = { users: PropTypes.array }
export default UserContent;