import { useEffect, useState } from 'react';
import CustomTable from './components/CustomTable';
import IconButtonWithTooltip from './components/IconButtonWithTooltip';
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";

const JournalForm = () => {
    const contents = journals === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <>
            <CustomTable
                initialState={{
                    density: "compact",
                    pagination: { pageIndex: 0, pageSize: 20 },
                }}
                columns={columns}
                data={journals}
                enableRowActions
                renderRowActions={({ row }) => {
                    return (
                        <div
                            style={{
                                width: "auto",
                                position: "relative",
                            }}
                        >
                            <>
                                <IconButtonWithTooltip
                                    tooltipTitle="Descargar"
                                    iconColor="#ff9100"
                                    IconComponent={<EditIcon />}
                                />
                                <IconButtonWithTooltip
                                    tooltipTitle="Eliminar agencia"
                                    iconColor="#C62828"
                                    IconComponent={<DeleteIcon />}
                                />
                            </>
                        </div>
                    );
                }}
            />
        </>;

    return JournalResponse =
        <div style={{ display: "flex", flexDirection: "column", alignItems: "top", }}>
            <h1 id="tableLabel">Journals</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div >;

    const [journals, setJournals] = useState([]);

    useEffect(() => {
        getJournals();
    }, []);

    const columns = [
        {
            enableEditing: false,
            accessorKey: "id",
            header: "ID",
        },
        {
            enableEditing: false,
            accessorKey: "ownerId",
            header: "Author",
        }
    ]


    async function getJournals() {
        const response = await fetch('/api/journals');
        try {
            const data = await response.json();
            setJournals(data);
        } catch (e) {
            setJournals(undefined);
        }
    }
}

export default JournalForm;
