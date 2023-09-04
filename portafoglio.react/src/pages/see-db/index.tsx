import { useLoaderData } from "react-router-dom"
import { BaseEntity } from "../../models/entities/base-entity"
import { Earning } from "../../models/entities/earning"
import { EarningSuddivision } from "../../models/entities/earning-suddivision"
import { Label } from "../../models/entities/label"
import { User } from "../../models/entities/user"
import { Wallet } from "../../models/entities/wallet"
import { DatabaseKey } from "../../utils/simil-axios-storage"
import { readFromStorage } from "../../utils/storage"

interface DbKeyValue {
	key: DatabaseKey,
	datas: BaseEntity[]
}

export const seeDbLoader = () => {
	const database: DbKeyValue[] = [
		{ key: DatabaseKey.user, datas: readFromStorage(DatabaseKey.user) as User[] },
		{ key: DatabaseKey.earningSuddivision, datas: readFromStorage(DatabaseKey.earningSuddivision) as EarningSuddivision[] },
		{ key: DatabaseKey.earning, datas: readFromStorage(DatabaseKey.earning) as Earning[] },
		{ key: DatabaseKey.label, datas: readFromStorage(DatabaseKey.label) as Label[] },
		{ key: DatabaseKey.wallet, datas: readFromStorage(DatabaseKey.wallet) as Wallet[] },
	]

	return database
}

export const SeeDb = () => {
	const datas = useLoaderData() as DbKeyValue[]

	return (
		<>
		{
			datas.map((data, indexData) => (
				<div key={data.key}>
					<h2>{data.key}</h2>
					<ul>
						{
							data.datas.map((item, indexItem) => (
								<li key={`${data.key}-${indexItem}`}>{JSON.stringify(item)}</li>
							))
						}
					</ul>
				</div>
			))
		}
		</>
	)
}