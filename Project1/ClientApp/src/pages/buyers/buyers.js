import React, { useState, useCallback } from 'react';
import { useNavigate } from "react-router-dom";
import './buyers.scss';
import ODataStore from 'devextreme/data/odata/store';
import DataGrid, {
    Column,
    Pager,
    Paging,
    FilterRow,
    Lookup,
    Selection
} from 'devextreme-react/data-grid';
import { SpeedDialAction } from 'devextreme-react/speed-dial-action';

export default () => {
    const [selectedId, setSelectedId] = useState(-1);
    const navigate = useNavigate();
    const datagrid = React.createRef();

    const addRow = useCallback((e) => {
        navigate('/buyers/new');
    });

    const editRow = useCallback((e) => {
        navigate(`/buyers/${selectedId}`);
    });

    const deleteRow = useCallback((e) => {
        if (window.confirm(`Вы действительно хотите удалить запись с id = ${selectedId}`)) {
            const url = `api/buyers/delete/${selectedId}`;

            fetch(url, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
            })
                .then(response => {
                    // перезагружаем источник с данными
                    datagrid.current.instance.refresh(true);
                    datagrid.current.instance.clearSelection();
                    setSelectedId(-1);
                })
                .catch(err => {
                    console.error(err);
                });
        }
    });

    const selectionChanged = useCallback((e) => {
        const id = e.selectedRowKeys[0];

        setSelectedId(id);
    });

    const dataSource = new ODataStore({
        url: '/odata/buyers',
        key: 'recId',
        keyType: 'Int32',
        version: 4,

        select: [
            'recId',
            'firstName',
            'secondName',
            'middleName',
            'sex',
            'birthDate',
            'registrationDate',
            'isAgree'
        ]
    });

    return (
        <React.Fragment>
            <h2 className={'content-block'}>Покупатели</h2>
            <div className={'content-block'}>
                <div className={'dx-card responsive-paddings'}>
                    <DataGrid ref={datagrid}
                        className={'dx-card wide-card'}
                        dataSource={dataSource}
                        showBorders={false}
                        focusedRowEnabled={true}
                        columnAutoWidth={true}
                        columnHidingEnabled={true}
                        onSelectionChanged={selectionChanged}
                    >
                        <Paging defaultPageSize={5} />
                        <Pager showPageSizeSelector={true} showInfo={true} />
                        <FilterRow visible={true} />
                        <Selection mode="single" />

                        <Column dataField={'recId'} />
                        <Column
                            dataField={'firstName'}
                            caption={'Имя'}
                        />
                        <Column
                            dataField={'secondName'}
                            caption={'Фамилия'}
                        />
                        <Column
                            dataField={'middleName'}
                            caption={'Отчество'}
                        />
                        <Column
                            dataField={'sex'}
                            caption={'Пол'}
                        >
                            <Lookup
                                dataSource={sexRus}
                                valueExpr={'value'}
                                displayExpr={'name'}
                            />
                        </Column>
                        <Column
                            dataField={'birthDate'}
                            caption={'ДР'}
                            dataType={'date'}
                        />
                        <Column
                            dataField={'registrationDate'}
                            caption={'Дата регистрации'}
                            dataType={'date'}
                        />
                        <Column
                            dataField={'isAgree'}
                            caption={'Согласие на обр. ПД'}
                            dataType={'boolean'}
                        />
                    </DataGrid>
                    <SpeedDialAction
                        icon="add"
                        label="Добавить"
                        index={1}
                        onClick={addRow} />
                    <SpeedDialAction
                        icon="trash"
                        label="Удалить"
                        index={2}
                        visible={selectedId !== undefined && selectedId !== -1}
                        onClick={deleteRow} />
                    <SpeedDialAction
                        icon="edit"
                        label="Редактировать"
                        index={3}
                        visible={selectedId !== undefined && selectedId !== -1}
                        onClick={editRow} />
                </div>
            </div>
        </React.Fragment>
    )
};

const sexRus = [
    { name: 'Муж', value: 'M' },
    { name: 'Жен', value: 'F' },
];