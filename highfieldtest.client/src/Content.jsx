import PropTypes from "prop-types";

function Content({ colours }) {
    if (colours === undefined) {
        return <p><em>Loading...</em></p>
    }
    return (
        <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Colour</th>
                    <th>Quantity</th>
                </tr>
            </thead>
            <tbody>
                {colours.map(colour =>
                    <tr key={colour.colour}>
                        <td style={{ backgroundColor: colour.colour.toLowerCase() }}>{colour.colour}</td>
                        <td>{colour.quantity}</td>

                    </tr>
                )}
            </tbody>
        </table>
    );
}
Content.propTypes = { colours: PropTypes.array }
export default Content;